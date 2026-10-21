using System;
using UnityEngine;

public class Enemy : AbsCharacter, IDamageable
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float initialHp = 100f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject FirePoint;
    void Awake()
    {
        this.rb = GetComponent<Rigidbody2D>();
        Hp = initialHp;
    }
    void OnEnable()
    {
        NavMeshEnemy.Attack += Attack;
        NavMeshEnemy.NoAttack += NoAttack;
    }
    private void OnDestroy()
    {
        NavMeshEnemy.Attack -= Attack;
        NavMeshEnemy.NoAttack -= NoAttack;
        Destroy(gameObject, 4f);
    }
    protected override void Attack()
    {
        FirePoint.SetActive(true);
        Debug.Log("enemy dang tan cong");
    }

    protected override void NoAttack()
    {
        FirePoint.SetActive(false);
        Debug.Log("enemy dang di chuyen den player");   
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
}
