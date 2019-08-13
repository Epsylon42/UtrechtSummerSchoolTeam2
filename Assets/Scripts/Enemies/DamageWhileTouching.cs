using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageWhileTouching : MonoBehaviour
{
    public bool DamagePlayer;

    public float DamagePerSecond;

    void OnCollisionStay2D(Collision2D collision)
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
