using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoredEnemyDeath : MonoBehaviour
{
    void Start()
    {
        GetComponentInChildren<Health>().OnHealthBelowZero = () => {
            Destroy(gameObject);
        };
    }
}
