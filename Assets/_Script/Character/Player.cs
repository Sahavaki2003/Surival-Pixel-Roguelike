using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private Transform weaponHolder;
    [SerializeField] private float initialHp = 100f;
    private bool hasGun = false;
    private IEquipable loodGun;
    public static event Action PlayerDie;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<IEquipable>() != null && !hasGun)
        {
            hasGun = true;
            Debug.Log("Player đã nhặt súng");
            loodGun = other.GetComponent<IEquipable>();
            loodGun.Equip(weaponHolder);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R) && hasGun)
        {
            loodGun.Unequip();
            hasGun = false;
            Debug.Log("Player đã bỏ súng");
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
        Debug.Log("player thông báo đã chếtok");
    }
}
