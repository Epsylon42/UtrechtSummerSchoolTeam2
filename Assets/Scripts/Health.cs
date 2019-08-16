using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float MaxHealth;
    public float CurrentHealth { get; private set; }
    public bool DestroySelfWhenBelowZero;
    public AudioClip HitSound;

    public GameObject AudioPlayerPrefab;
    public float HitVolume = 0.5f;
    private GameObject audioSource;

    public System.Action OnHealthBelowZero;

    public void Damage(float damage)
    {
        if (HitSound != null && AudioPlayerPrefab != null && audioSource == null)
        {
            audioSource = Instantiate(AudioPlayerPrefab);
            var source = audioSource.GetComponent<AudioSource>();
            source.GetComponent<TimeToLive>().TimeLeft = HitSound.length;
            source.volume = HitVolume;
            source.PlayOneShot(HitSound);
        }

        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            if (OnHealthBelowZero != null)
            {
                OnHealthBelowZero.Invoke();
            }
            if (DestroySelfWhenBelowZero)
            {
                Destroy(gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }
}
