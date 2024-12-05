using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePlayerAttack : MonoBehaviour
{
    [SerializeField] protected float _attackPower = 10f;
    [SerializeField] protected float _attackCoolDown = 1f;

    protected bool _isAttackCoolDown = false;
    
    public void TryAttack()
    {
        if (!_isAttackCoolDown)
        {
            Attack();
            StartCoroutine(AttackCoolDown());
        }
         
    }
    public abstract void Attack();
    protected IEnumerator AttackCoolDown()
    {
        _isAttackCoolDown = true;
        yield return new WaitForSeconds(_attackCoolDown);
        _isAttackCoolDown = false;
    }
}
