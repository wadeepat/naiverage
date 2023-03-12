using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private MainMenu mainMenu;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private TMP_Dropdown graphicsDropdown;
    [SerializeField] private Slider audioSlider;
    private void Update()
    {
        if (InputManager.instance.GetBackPressed()) onBackClicked();
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
    }
    public void SetQuality(int qualityIdx)
    {
        QualitySettings.SetQualityLevel(qualityIdx + 1);
        PlayerPrefs.SetInt("graphics", qualityIdx + 1);
    }
    public bool IsActivated()
    {
        return this.gameObject.activeSelf;
    }
    public void onBackClicked()
    {
        Debug.Log("disable at setting");
        this.DeactivateMenu();
        mainMenu?.ActivateMenu();
    }
    public void LoadSettings()
    {
        graphicsDropdown.value = PlayerPrefs.GetInt("graphics", 3) - 1;
        SetQuality(PlayerPrefs.GetInt("graphics", 3) - 1);

        audioSlider.value = PlayerPrefs.GetFloat("volume", 0);
        SetVolume(PlayerPrefs.GetFloat("volume", 0));
    }
    public void ActivateMenu()
    {
        // Debug.Log(PlayerPrefs.GetInt("graphics"));
        // Debug.Log(PlayerPrefs.GetFloat("volume"));

        LoadSettings();
        // if (!PlayerPrefs.HasKey("graphics"))
        // {
        //     graphicsDropdown.value = 3;
        //     SetQuality(3);
        // }
        // else
        // {
        //     graphicsDropdown.value = PlayerPrefs.GetInt("graphics");
        //     SetQuality(PlayerPrefs.GetInt("graphics"));
        // }

        // if (!PlayerPrefs.HasKey("volume"))
        // {
        //     audioSlider.value = 0;
        //     SetVolume(0);
        // }
        // else
        // {
        //     audioSlider.value = PlayerPrefs.GetFloat("volume");
        //     SetVolume(PlayerPrefs.GetFloat("volume"));
        // }
        this.gameObject.SetActive(true);
    }
    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }
}
