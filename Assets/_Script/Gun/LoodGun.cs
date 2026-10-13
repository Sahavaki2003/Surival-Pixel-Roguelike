using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoodGun : MonoBehaviour, IEquipable
{
    [SerializeField] private GameObject Bullet;
    void Update()
    {
        this.Unequip();
    }
    public void Equip(Transform weaponHolder)
    {
        transform.SetParent(weaponHolder);

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        Bullet.SetActive(true);
    }
    public void Unequip()
    {
        if (Input.GetKey(KeyCode.R))
        {
            transform.SetParent(null);
            Bullet.SetActive(false);
        }
    }
}
