using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePlayerAttack : MonoBehaviour
{
    [SerializeField] protected BoxCollider2D _playerBoxCollider = default;
    [SerializeField] protected float _attackPower = 10f;
    [SerializeField] protected float _attackCoolDown = 1f;

    protected bool _isAttackCoolDown = false;

    public void TryAttack()
    {
        if (!_isAttackCoolDown)
        {
            Attack();
        }
    }
    public abstract void Attack();
   
}
