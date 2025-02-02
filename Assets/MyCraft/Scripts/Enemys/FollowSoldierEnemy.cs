using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �ǔ�����G
/// </summary>
public class FollowSoldierEnemy : BaseEnemy
{
   

    private void Start()
    {
        Defence = 5;
        // �ړ��ƃW�����v�̋@�\��ݒ�
        SetMovement(gameObject.GetComponent<FollowSoldierEnemyMove>());

        // �ߐڍU����ݒ�
        SetAttack(gameObject.GetComponent<SoldierEnemyAttack>());
        //�v���C���[�����m����
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
            Move(); // �O�i
        }
        if (_sense.IsAttack)
        {
            Attack();   // �U��
            //_enemyStateController.ChangeState(EnemyStateController.EnemyState.Attacking);
        }
        else
        {
            //_enemyStateController.ChangeState(EnemyStateController.EnemyState.Walking);
        }
        
        Sense();//�T�m
    }
}
