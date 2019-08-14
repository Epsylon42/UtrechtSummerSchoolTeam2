using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectiles : MonoBehaviour
{
    public GameObject Projectile;
    public float ProjectileDamage;
    public float ProjectileSpeed;
    public float ProjectilesPerSecond;
    public float ProjectileSpawnDistance;

    private float cooldown;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (cooldown <= 0)
            {
                cooldown = 1.0f / ProjectilesPerSecond;
                var mouseInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var tf = GetComponent<Transform>();
                var direction = mouseInWorld - tf.position;
                direction.Normalize();

                var projectile = Instantiate(
                    Projectile,
                    tf.position + direction * ProjectileSpawnDistance,
                    Quaternion.identity
                    );

                var damage = projectile.GetComponent<BurstDamage>();
                damage.DamageEnemies = true;
                damage.Damage = ProjectileDamage;
                damage.NumberOfBounces = 0;

                projectile.GetComponent<Rigidbody2D>().velocity = direction * ProjectileSpeed;
            }
        }

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        if (cooldown < 0)
        {
            cooldown = 0;
        }
    }
}
