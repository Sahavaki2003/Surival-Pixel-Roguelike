
using UnityEngine;

public class Enemy : AbsCharacter, IDamageable, ITeamMember
{
    [Header("Health")]
    [SerializeField] private float initialHp = 100f;
    public TeamType Team => TeamType.Enemy;
    
    [Header("Attack Settings")]
    [SerializeField] private GameObject FirePoint;
    [SerializeField] private Transform Target;
    [SerializeField] private float actionDistance = 2f;

    private bool isAttacking;
    private bool isDead;

    private void Awake()
    {
        Hp = initialHp;
    }

    private void OnEnable()
    {
        GameObject playerObj = GameObject.Find("Player");

        if (playerObj != null)
        {
            Target = playerObj.transform;
        }
    }

    private void Start()
    {
        if (FirePoint != null)
        {
            FirePoint.SetActive(false);
        }
    }

    private void Update()
    {
        if (Target == null || isDead)
            return;

        GetDistance();
    }

    private void GetDistance()
    {
        float distance = Vector2.Distance(transform.position,Target.position);

        bool shouldAttack = distance <= actionDistance;

        // Chỉ xử lý khi trạng thái thay đổi
        if (shouldAttack == isAttacking)
            return;

        isAttacking = shouldAttack;

        if (isAttacking)
        {
            Attack();
        }
        else
        {
            NoAttack();
        }
    }

    protected override void Attack()
    {
        if (FirePoint != null)
            FirePoint.SetActive(true);

        Debug.Log("Enemy đang tấn công");
    }

    protected override void NoAttack()
    {
        if (FirePoint != null)
            FirePoint.SetActive(false);

        Debug.Log("Enemy đang di chuyển đến Player");
    }

    public void TakeDamage(float damage)
    {
        if (isDead)return;

        Hp -= damage;

        if (Hp <= 0)
        {
            Hp = 0;
            OnDie();
        }
    }

    protected override void OnDie()
    {
        if (isDead)
            return;

        isDead = true;

        if (FirePoint != null)
            FirePoint.SetActive(false);

        base.OnDie();

        EnemyWaveMember waveMember = GetComponent<EnemyWaveMember>();

        if (waveMember != null)
        {
            waveMember.ReportDeath();
        }

        Destroy(gameObject, 2f);
    }
}
