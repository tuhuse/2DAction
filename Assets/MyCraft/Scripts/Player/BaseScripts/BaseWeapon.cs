using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{

    [SerializeField] protected GameObject _weapon = default;
    [SerializeField] protected float _attackCoolDown = 1f;
    protected bool _isAttackCoolDown = false;
    public int AttackPower { get; set; }
    public void TryAttack()
    {
        if (!_isAttackCoolDown)
        {
            Attack();
        }
    }
    public abstract void Attack();
   
}
