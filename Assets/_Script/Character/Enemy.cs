using System;
using UnityEngine;

public class Enemy : AbsCharacter, IDamageable
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float initialHp = 100f;
    void Awake()
    {
        Hp = initialHp;
    }
    protected override void Attack()
    {
        // Logic tấn công của Enemy
    }
    public void TakeDamage(float damage)
    {
        Hp -= damage;
        initialHp = Hp;
        if (Hp <= 0)
        {
            Hp = 0;
            initialHp = 0;
            Debug.Log("Enemy đã chết");
            this.OnDie();
            this.OnDestroy();
        }
    }
    protected override void OnDie()
    {
        base.OnDie();
    }
    protected void OnDestroy()
    {
        Destroy(enemy, 4f);
    }
}
