using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemyAttack : MonoBehaviour
{
    [SerializeField] protected BoxCollider2D _boxCollider2D;
    protected bool _isAttackCoolDown = false;
    protected float AttackCoolTime { get; set; } = 2f;
    protected float AttackPower = 5f;
    public abstract void EnemyAttack();
}
