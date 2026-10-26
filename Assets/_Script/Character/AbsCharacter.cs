using UnityEngine;
using System;
public abstract class AbsCharacter: MonoBehaviour
{
    protected float Hp;

    protected abstract void Attack();
    protected abstract void NoAttack();
    protected abstract void OnDie();
}
