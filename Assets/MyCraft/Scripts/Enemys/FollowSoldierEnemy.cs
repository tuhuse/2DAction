using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 追尾する敵
/// </summary>
public class FollowSoldierEnemy : BaseEnemy
{
   

    private void Start()
    {
        Defence = 5;
        // 移動とジャンプの機能を設定
        SetMovement(gameObject.GetComponent<FollowSoldierEnemyMove>());

        // 近接攻撃を設定
        SetAttack(gameObject.GetComponent<SoldierEnemyAttack>());
        //プレイヤーを感知する
        SetSense(gameObject.GetComponent<SoldierSensePlayer>());
    }
    public override void EnemyUpdate()
    {

        if (_sense.IsLeftFindPlayer)
        {
            FollowLeftMove();
        }
        else if (_sense.IsRightFindPlayer)
        {
            FollowRightMove();
        }
        else
        {
            Move(); // 前進
        }
        if (_sense.IsAttack)
        {
            Attack();   // 攻撃
            //_enemyStateController.ChangeState(EnemyStateController.EnemyState.Attacking);
        }
        else
        {
            //_enemyStateController.ChangeState(EnemyStateController.EnemyState.Walking);
        }
        
        Sense();//探知
    }
}
