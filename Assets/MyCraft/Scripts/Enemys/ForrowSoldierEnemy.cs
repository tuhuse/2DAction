using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForrowSoldierEnemy : BaseEnemy
{
    private void Start()
    {
        // �ړ��ƃW�����v�̋@�\��ݒ�
        SetMovement(gameObject.GetComponent<ForrowSoldierEnemyMove>());

        // �ߐڍU����ݒ�
        SetAttack(gameObject.GetComponent<SoldierEnemyAttack>());
    }

    private void Update()
    {
        Move(); // �O�i
        Attack();   // �U��
    }
}
