using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForrowSoldierEnemy : BaseEnemy
{
    private void Start()
    {
        // 移動とジャンプの機能を設定
        SetMovement(gameObject.GetComponent<ForrowSoldierEnemyMove>());

        // 近接攻撃を設定
        SetAttack(gameObject.GetComponent<SoldierEnemyAttack>());
    }

    private void Update()
    {
        Move(); // 前進
        Attack();   // 攻撃
    }
}
