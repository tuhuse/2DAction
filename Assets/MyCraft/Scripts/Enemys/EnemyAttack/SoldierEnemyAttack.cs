using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �G�����̍U���X�N���v�g
/// </summary>
public class SoldierEnemyAttack : BaseEnemyAttack
{
    private void Start()
    {
        AttackPower = 2;
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
        _boxCollider2D.enabled = true;
        _isAttackCoolDown = true;
        yield return new WaitForSeconds(AttackCoolTime);
        _boxCollider2D.enabled = false;
        yield return new WaitForSeconds(AttackCoolTime);
        _isAttackCoolDown = false;
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }
}
