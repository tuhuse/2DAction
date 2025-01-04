using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSoldierEnemy : BaseEnemy
{
    private void Start()
    {
        // �ړ��ƃW�����v�̋@�\��ݒ�
        SetMovement(gameObject.GetComponent<FollowSoldierEnemyMove>());

        // �ߐڍU����ݒ�
        SetAttack(gameObject.GetComponent<SoldierEnemyAttack>());
        //�v���C���[�����m����
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
            Move(); // �O�i
        }    
        Attack();   // �U��
        Sense();//�T�m
    }

}
