using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ìGÇÃçUåÇ
/// </summary>
public abstract class BaseEnemyAttack : MonoBehaviour
{   
    protected bool _isAttackCoolDown = false;
    protected float AttackCoolTime { get; set; } = 2f;
    public int AttackPower { get; set; }
    public abstract void EnemyAttack();
}
