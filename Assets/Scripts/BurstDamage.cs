using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstDamage : MonoBehaviour
{
    public bool DamageEnemies;
    public uint NumberOfBounces = 0;
    public float Damage;

    void Update()
    {
        GetComponent<Transform>().rotation =
            Quaternion.LookRotation(
                GetComponent<Rigidbody2D>().velocity,
                Vector3.forward
                );
    }

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (DamageEnemies)
    //     {
    //         if (collision.gameObject.GetComponentInParent<EnemyMarker>())
    //         {
    //             var health = collision.gameObject.GetComponent<Health>();
    //             if (health != null)
    //             {
    //                 health.Damage(Damage);
    //                 Destroy(gameObject);
    //                 return;
    //             }
    //         }
    //     }

    //     if (NumberOfBounces == 0)
    //     {
    //         Destroy(gameObject);
    //     }
    //     else
    //     {
    //         NumberOfBounces -= 1;
    //         var body = GetComponent<Rigidbody2D>();
    //         var normal = collision.contacts[0].normal;
    //         body.velocity = Vector2.Reflect(body.velocity, normal);

    //         body.position += body.velocity * Time.deltaTime * 0.1f;
    //     }
    // }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (DamageEnemies)
        {
            if (collision.gameObject.GetComponentInParent<EnemyMarker>())
            {
                var health = collision.gameObject.GetComponent<Health>();
                if (health != null)
                {
                    health.Damage(Damage);
                    Destroy(gameObject);
                    return;
                }
            }
        }

        if (NumberOfBounces == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            var tf = GetComponent<Transform>();
            var body = GetComponent<Rigidbody2D>();
            RaycastHit hit;
            Debug.DrawLine(tf.position, tf.position + (Vector3)body.velocity * 3.0f, Color.white, 5.0f);
            if (Physics.Raycast(tf.position, body.velocity, out hit, 1.0f))
            {
                Debug.Log("Ray hit");
                NumberOfBounces -= 1;
                body.velocity = Vector2.Reflect(body.velocity, hit.normal);
                body.position += body.velocity * Time.deltaTime * 0.1f;
            }
            else
            {
                Debug.Log("No hit");
                Destroy(gameObject);
            }
        }
    }
}
