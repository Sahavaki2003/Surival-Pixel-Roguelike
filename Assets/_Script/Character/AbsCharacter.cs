using UnityEngine;
using System;
public abstract class AbsCharacter: MonoBehaviour
{
    protected float Hp;
    protected abstract void Attack();
    protected abstract void NoAttack();
    public static event Action EnemyDie;
    protected virtual void OnDie()
    {
        EnemyDie?.Invoke();
        Debug.Log("enemy đã chết");
    }
}
