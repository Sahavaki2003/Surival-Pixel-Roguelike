using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShooterEnemy : AbsAutoShooter
{
    [SerializeField] private Transform target;
    [SerializeField] private float fireRateEnemy = 1f;
    [SerializeField] private float bulletSpeedEnemy = 5f;


    void Awake()
    {
        this.fireRate = fireRateEnemy;
        this.bulletSpeed = bulletSpeedEnemy;
    }
    protected override void OnEnable()
    {
        GameObject player = GameObject.Find("Player");

        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogWarning("Không tìm thấy GameObject Player!");
        }
        base.OnEnable();
    }
    protected override GameObject SpawnBullet()
    {
        GameObject bullet = base.SpawnBullet();

        if (bullet == null || target == null)
            return bullet;

        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        if (bulletRb != null)
        {
            Vector2 direction =
                (target.position - firePoint.position).normalized;

            bulletRb.velocity = direction * bulletSpeed;
        }

        return bullet;
    }
}
