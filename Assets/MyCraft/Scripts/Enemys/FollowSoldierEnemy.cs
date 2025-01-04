using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSoldierEnemy : BaseEnemy
{
    private void Start()
    {
        // 移動とジャンプの機能を設定
        SetMovement(gameObject.GetComponent<FollowSoldierEnemyMove>());

        // 近接攻撃を設定
        SetAttack(gameObject.GetComponent<SoldierEnemyAttack>());
        //プレイヤーを感知する
        SetSense(gameObject.GetComponent<SoldierSensePlayer>());
    }

    private void Update()
    {
        if (_sense.IsLeftFindPlayer)
        {
            FollowLeftMove();
        }else if (_sense.IsRightFindPlayer)
        {
            FollowRightMove();
        }
        else
        {
            Move(); // 前進
        }    
        Attack();   // 攻撃
        Sense();//探知
    }

}
