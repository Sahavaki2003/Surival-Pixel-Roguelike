using System;
using UnityEngine;

public class BulletPistol : AbsWeapon
{
    [SerializeField] private WeaponData data;
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
            gameObject.SetActive(false);
        }
    }
}