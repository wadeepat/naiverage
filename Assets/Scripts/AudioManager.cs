using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    [Header("sfx Config")]
    [SerializeField] private AudioMixerGroup mixer;
    [SerializeField] private float timeToFade = 0.5f;
    [SerializeField] private float timeElapsed = 0;
    public Sound[] sounds;
    public static AudioManager instance { get; private set; }
    private string _playingSoundName = "";
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = mixer;
        }
    }
    public void Play(string name)
    {
        Sound sound = FindSoundWithName(name);
        if (!sound.source.isPlaying)
        {
            sound.source.Play();
            if (name == "battle")
            {
                timeElapsed = 0.2f;
                StartCoroutine(FadeIn(sound));
            }
        }
        if (sound.loop)
        {
            _playingSoundName = name;
        }
    }
    public void Stop(string name)
    {
        Sound sound = FindSoundWithName(name);
        if (!sound.source.isPlaying) return;
        if (name != "battle")
            sound.source.Stop();
        else
        {
            timeElapsed = 0.2f;
            StartCoroutine(FadeOut(sound));
        }
        _playingSoundName = "";
    }
    public bool IsPlaying(string name)
    {
        Sound sound = FindSoundWithName(name);
        return sound.source.isPlaying;
    }
    private Sound FindSoundWithName(string name)
    {
        Sound sound = Array.Find(sounds, s => s.s_name == name);
        if (sound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
        }
        return sound;
    }
    public void SwapTrack(string newSound)
    {
        StartCoroutine(FadeSound(newSound));
    }
    private IEnumerator FadeIn(Sound sound)
    {
        Debug.Log("Fade In");
        // Sound sound = FindSoundWithName(name);
        // float volume_temp = sound.source.volume;
        sound.source.Play();
        while (timeElapsed < timeToFade)
        {
            sound.source.volume = Mathf.Lerp(0, sound.volume, timeElapsed / timeToFade);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        // sound.source.volume = sound.volume;
    }
    private IEnumerator FadeOut(Sound sound)
    {
        Debug.Log("Fade out");
        // Sound sound = FindSoundWithName(name);
        while (timeElapsed < timeToFade)
        {
            sound.source.volume = Mathf.Lerp(sound.volume, 0, timeElapsed / timeToFade);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        sound.source.Stop();
        sound.source.volume = sound.volume;
    }
    private IEnumerator FadeSound(string newSound)
    {

        AudioSource sound2 = FindSoundWithName(newSound).source;

        if (_playingSoundName != "")
        {
            AudioSource sound1 = FindSoundWithName(_playingSoundName).source;
            float volume1 = sound1.volume;
            float volume2 = sound2.volume;

            sound2.Play();

            while (timeElapsed < timeToFade)
            {
                sound1.volume = Mathf.Lerp(volume1, 0, timeElapsed / timeToFade);
                sound2.volume = Mathf.Lerp(0, volume2, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            sound1.Stop();
            sound1.volume = volume1;
        }
        else
        {
            sound2.Play();
        }
        _playingSoundName = newSound;
        yield return null;
    }

    public void StopAllTrack()
    {
        foreach (Sound sound in sounds)
        {
            if (sound.source.isPlaying && sound.source.loop)
            {
                sound.source.Stop();
            }
        }
    }
}
