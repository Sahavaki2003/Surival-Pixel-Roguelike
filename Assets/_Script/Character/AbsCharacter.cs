using UnityEngine;
using System;
public abstract class AbsCharacter: MonoBehaviour
{
    //protected GameObject enemyPrefab;
    protected Transform player;
    protected float Hp;
    protected float speed;
    protected abstract void Attack();
    public static event Action EnemyDie;
    protected virtual void OnEnable()
    {
        this.Target();
        //this.Spawner();
    }

    protected void Update()
    {
        this.MoveTarget();
    }
    // protected void Spawner()
    // {
    //     Invoke(nameof(SpawnEnemy), 2f);
    // }
    // protected void SpawnEnemy()
    // {
    //     Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    // }
    protected void Target()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Player");

        if (target != null)
        {
            player = target.transform;
        }
    } 
    protected void MoveTarget()
    {
        if (player == null) return;

        Vector2 direction = ((Vector2)player.position - (Vector2)transform.position).normalized;

        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }
    protected virtual void OnDie()
    {
        EnemyDie?.Invoke();
        Debug.Log("player thông báo đã chết, hoặc enemy đã chết");
    }
}
