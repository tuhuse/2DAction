using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SordWeapon : BaseWeapon
{
    
    private void Start()
    {
        AttackPower = 40;

    }
    public override void Attack()
    {
       
        StartCoroutine(AttackCoolDown());
    }
    protected IEnumerator AttackCoolDown()
    {
        _weapon.SetActive(true);
        _isAttackCoolDown = true;
        yield return new WaitForSeconds(_attackCoolDown);
        _weapon.SetActive(false);
        yield return new WaitForSeconds(_attackCoolDown);
        _isAttackCoolDown = false;
    }
}
