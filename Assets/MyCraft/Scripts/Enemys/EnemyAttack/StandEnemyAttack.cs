using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandEnemyAttack : BaseEnemyAttack
{
    [SerializeField] protected GameObject _attack;
    private void Start()
    {
        AttackPower = 40;
        AttackCoolTime = 3;
    }
    public override void EnemyAttack()
    {
        if (!_isAttackCoolDown)
        {
            StartCoroutine(AttackCoolDown());
        }
    }
    protected IEnumerator AttackCoolDown()
    {
        _attack.SetActive(true);
        _isAttackCoolDown = true;
        yield return new WaitForSeconds(AttackCoolTime);
        _attack.SetActive(false);
        yield return new WaitForSeconds(AttackCoolTime);
        _isAttackCoolDown = false;

    }
}
