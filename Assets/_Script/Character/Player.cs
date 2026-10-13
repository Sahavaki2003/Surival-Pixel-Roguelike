using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private Transform weaponHolder;
    [SerializeField] private float initialHp = 100f;
    public static event Action PlayerDie;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<IEquipable>() != null)
        {
            Debug.Log("Player đã nhặt súng");
            IEquipable LoodGun = other.GetComponent<IEquipable>();
            LoodGun.Equip(weaponHolder);

        }
    }
    public void TakeDamage(float damage)
    {
        initialHp -= damage;
        Debug.Log(initialHp);
        if (initialHp <= 0)
        {
            initialHp = 0;
            Debug.Log("Player đã chết");
            this.OnDie();
        }
    }
    private void OnDie()
    {
        PlayerDie?.Invoke();
        Debug.Log("player thông báo đã chết");
    }
}
