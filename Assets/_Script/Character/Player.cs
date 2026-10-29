using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : AbsCharacter, IDamageable, ITeamMember
{
    [Header("Health")]
    [SerializeField] private float initialHp = 100f;
    public TeamType Team => TeamType.Player;
    
    [Header("Settings")]
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Transform weaponHolder;
    private bool hasGun = false;
    private IEquipable loodGun;
    public static event Action PlayerDie;
    void Awake()
    {
        Hp = initialHp;
    }
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
    void Start()
    {
        // Hiển thị thanh máu đầy khi bắt đầu game
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(Hp, initialHp);
        }
    }
    protected override void Attack()
    {
        Debug.Log("Player đang tấn công");
    }

    protected override void NoAttack()
    {
        Debug.Log("player đang di chuyển đến Player");
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

    //Tính toán trừ máu và cập nhật thanh máu khi bị trừ
    public void TakeDamage(float damage)
    {
        if (Hp <= 0f) return;

        // Trừ máu hiện tại, không trừ máu tối đa
        Hp -= damage;
        Hp = Mathf.Clamp(Hp, 0f, initialHp);

        Debug.Log("Player HP: " + Hp);

        // Cập nhật thanh máu
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(Hp, initialHp);
        }
        else
        {
            Debug.LogError("Chưa gán HealthBar trong Inspector!");
        }

        if (Hp <= 0f)
        {
            Debug.Log("Player đã chết");
            OnDie();
        }
    }
    protected override void OnDie()
    {
        PlayerDie?.Invoke();
        Debug.Log("player thông báo đã chếtok");
    }
}
