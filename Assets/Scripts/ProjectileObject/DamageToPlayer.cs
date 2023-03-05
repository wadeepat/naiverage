using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToPlayer : MonoBehaviour
{
    [SerializeField] public int damageAmount = 20;
    [SerializeField] private GameObject explosionFx;
    // [SerializeField] private AudioClip explosionClip;
    [SerializeField] private AudioClip explosionSound;
    public void SetDamage(int damage)
    {
        this.damageAmount = damage;
    }
    // private void Start()
    // {
    //     // explosionSound = new AudioSource();
    //     // explosionSound.sou
    // }
    private void OnTriggerEnter(Collider target)
    {
        // Destroy(gameObject);
        if (target.gameObject.tag.Contains("Player"))
        {
            if (explosionFx)
            {
                GameObject explosion = Instantiate(explosionFx, transform.position, transform.rotation);
                if (explosionSound)
                {
                    AudioSource sound = explosion.AddComponent<AudioSource>();
                    sound.clip = explosionSound;
                    sound.volume = 0.35f;
                    sound.Play();
                }
                Destroy(explosion, 1);
                Destroy(gameObject);
            }
            target.gameObject.GetComponent<PlayerStatus>().TakeDamaged(damageAmount);
        }
        else if (target.gameObject.tag == "Victim")
        {
            target.GetComponent<Victim>().TakeDamaged(damageAmount, ElementType.Physical);
        }
        else if (target.gameObject.name == "Terrain")
            Destroy(gameObject);
    }
}
