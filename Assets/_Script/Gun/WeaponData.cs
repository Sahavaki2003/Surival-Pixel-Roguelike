using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Weapon Data")]
public class WeaponData : ScriptableObject
{
    [SerializeField] private string weaponName;
    [SerializeField] private float damage;
    [SerializeField] private float speedGun;

    public string WeaponName => weaponName;
    public float Damage => damage;
    public float SpeedGun => speedGun;
}
