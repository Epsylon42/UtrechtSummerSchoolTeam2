﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float MaxHealth;
    public float CurrentHealth { get; private set; }
    public bool DestroySelfWhenBelowZero;
    public AudioClip HitSound;

    public System.Action OnHealthBelowZero;

    public void Damage(float damage)
    {
        if (HitSound != null)
        {
            GetComponent<AudioSource>().PlayOneShot(HitSound);
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
