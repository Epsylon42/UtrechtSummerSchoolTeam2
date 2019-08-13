using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float MaxHealth;
    public float CurrentHealth { get; private set; }

    public System.Action OnHealthBelowZero;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0 && OnHealthBelowZero != null)
        {
            OnHealthBelowZero.Invoke();
        }
    }
}
