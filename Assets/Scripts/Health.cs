using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float MaxHealth;
    public float CurrentHealth { get; private set; }

    public System.Action OnHealthBelowZero;

    public void Damage(float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0 && OnHealthBelowZero != null)
        {
            OnHealthBelowZero.Invoke();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }
}
