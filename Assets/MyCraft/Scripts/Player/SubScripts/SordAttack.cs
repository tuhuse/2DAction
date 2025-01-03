using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SordAttack : BasePlayerAttack
{
    
    private void Start()
    {
           
        _playerBoxCollider.enabled = false;

    }
    public override void Attack()
    {
        _playerBoxCollider.enabled = true;
        StartCoroutine(AttackCoolDown());
    }
    protected IEnumerator AttackCoolDown()
    {
        _isAttackCoolDown = true;
        yield return new WaitForSeconds(_attackCoolDown);
        _playerBoxCollider.enabled = false;
        yield return new WaitForSeconds(_attackCoolDown);
        _isAttackCoolDown = false;
    }
}
