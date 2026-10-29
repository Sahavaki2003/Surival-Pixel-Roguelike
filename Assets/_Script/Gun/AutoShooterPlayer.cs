using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShooterPlayer : AbsAutoShooter
{
    [SerializeField] private Transform target;
    [SerializeField] private float fireRatePlayer = 1f;
    [SerializeField] private float bulletSpeedPlayer = 5f;

    void Awake()
    {
        this.fireRate = fireRatePlayer;
        this.bulletSpeed = bulletSpeedPlayer;
    }
    protected override void OnEnable()
    {
        this.IntanceGameobj();
        base.OnEnable();
    }
    private void IntanceGameobj()
    {
        GameObject player = GameObject.Find("Enemy");

        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogWarning("Không tìm thấy GameObject Enemy!");
        }
    }
    protected override GameObject SpawnBullet()
    {
        GameObject bullet = base.SpawnBullet();

        if (bullet == null || target == null)
            return bullet;

        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        if (bulletRb != null)
        {
            Vector2 direction =(target.position - firePoint.position).normalized;

            bulletRb.velocity = direction * bulletSpeed;
        }

        return bullet;
    }
}
