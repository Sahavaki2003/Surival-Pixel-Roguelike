using System;
using UnityEngine;

public class BulletPistol : AbsWeapon
{
    [SerializeField] private WeaponData data;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed = 1f;
    private float timer;

    void Awake()
    {
        this.Damage = data.Damage;
    }
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<IDamageable>() != null)
        {
            Debug.Log("Player hoặc enemy đã Va chạm");
            IDamageable damageable = other.GetComponent<IDamageable>();
            damageable.TakeDamage(Damage);
        }
    }
    public void Shoot()//spawn vien dan
    {
        if (firePoint == null || Bullet == null) return;

        GameObject bullet = Instantiate(Bullet,
        firePoint.position,
        firePoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = firePoint.right * bulletSpeed;
        }
    }
}