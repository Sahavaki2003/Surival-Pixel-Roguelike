using UnityEngine;

public interface IEquipable
{
    void Equip(Transform weaponHolder);
    void Unequip();
}
