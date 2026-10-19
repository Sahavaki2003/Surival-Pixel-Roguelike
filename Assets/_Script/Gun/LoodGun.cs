using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoodGun : MonoBehaviour, IEquipable
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject Bullet;
    void Awake()
    {
        this.rb = GetComponent<Rigidbody2D>();
        Bullet.SetActive(false);
    }
    public void Equip(Transform weaponHolder)
    {   
        transform.SetParent(weaponHolder);

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        rb.simulated = false;
        Debug.Log(rb.simulated + "đã tắt rigibody");
        Bullet.SetActive(true);
    }

    public void Unequip()
    {
        transform.SetParent(null);
        rb.simulated = true;
        Debug.Log(rb.simulated + "đã tắt rigibody");
        Bullet.SetActive(false);
    }
}
