using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageWhenTouching : MonoBehaviour
{
    public bool DamagePlayer;

    public float DamagePerSecond;

    void OnCollisionStay(Collision collision)
    {
        if (DamagePlayer)
        {
            if (collision.gameObject.GetComponent<PlayerMarker>())
            {
                collision
                    .gameObject
                    .GetComponent<Health>()
                    .Damage(DamagePerSecond * Time.deltaTime);
            }
        }
    }
}
