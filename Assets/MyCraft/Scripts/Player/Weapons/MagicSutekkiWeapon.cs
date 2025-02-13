using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSutekkiWeapon : BaseWeapon
{
    public override void Attack()
    {
            StartCoroutine(AttackCoolDown());
    }
    protected IEnumerator AttackCoolDown()
    {
        _weapon.SetActive(true);
        _isAttackCoolDown = true;
        float totalTime = AttackingTime + AttackInterval;
        yield return new WaitForSeconds(AttackingTime);
        _weapon.SetActive(false);
        print("End");
        yield return new WaitForSeconds(AttackInterval);
        _isAttackCoolDown = false;
        print("Start");
        Debug.Log("Total Cooldown Time: " + totalTime);
    }
}
