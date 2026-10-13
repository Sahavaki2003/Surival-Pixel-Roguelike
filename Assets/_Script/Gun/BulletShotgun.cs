using System;
using UnityEngine;

public class BulletShotgun : AbsWeapon, IGun
{    
    [SerializeField] private WeaponData data;
    void Awake()
    {
        this.Damage = data.Damage;
    }
    public void Shoot()
    {
        //Logic bắn
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
}
