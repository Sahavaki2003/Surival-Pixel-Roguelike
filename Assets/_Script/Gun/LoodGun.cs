using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoodGun : MonoBehaviour, IEquipable
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject FirePoint;
    void Awake()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }

    //Nhặt súng thì sẽ bật FirePoint sẽ auto tự bắn, tiếp theo sét vị trí của súng đã nhặt vào vị trí weaponHolder rồi setup về 
    //vị trí và góc quay và tắt rb
    public void Equip(Transform weaponHolder)
    {   
        FirePoint.SetActive(true);
        
        transform.SetParent(weaponHolder);

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        rb.simulated = false;
        Debug.Log(rb.simulated + "đã tắt rigibody");
    }

    // tháo súng sẽ tắt bắn và set vị trí thành rỗng và tắt rb
    public void Unequip()
    {
        FirePoint.SetActive(false);

        transform.SetParent(null);
        rb.simulated = true;
        Debug.Log(rb.simulated + "đã tắt rigibody");
    }
}
