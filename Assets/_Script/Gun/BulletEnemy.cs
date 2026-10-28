using System;
using UnityEngine;

public class BulletEnemy : AbsWeapon
{
    [SerializeField] private TeamType ownerTeam;
    [SerializeField] private WeaponData data;
    void Awake()
    {
        this.Damage = data.Damage;
    }
    protected void OnTriggerEnter2D(Collider2D other)
    {
        ITeamMember targetTeam = other.GetComponentInParent<ITeamMember>();

        // Không tìm thấy đối tượng có phe
        if (targetTeam == null)
            return;

        // Không gây sát thương lên cùng phe
        if (targetTeam.Team == ownerTeam)
            return;
        if(other.GetComponent<IDamageable>() != null)
        {
            Debug.Log("Player hoặc enemy đã Va chạm");
            IDamageable damageable = other.GetComponent<IDamageable>();
            damageable.TakeDamage(Damage);
            gameObject.SetActive(false);
        }
    }
}