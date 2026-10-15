using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoodGun : MonoBehaviour, IEquipable
{
    [SerializeField] private Rigidbody2D rb;
    //[SerializeField] private GameObject Bullet;
    void Awake()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        this.Unequip();
    }
    public void Equip(Transform weaponHolder)
    {
        transform.SetParent(weaponHolder);

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        rb.simulated = false;
        Debug.Log(rb.simulated + "đã tắt rigibody");
    }
    public void Unequip()
    {
        if (Input.GetKey(KeyCode.R))
        {
            transform.SetParent(null);
            rb.simulated = true;
            Debug.Log(rb.simulated + "đã tắt rigibody");
        }
    }
}
