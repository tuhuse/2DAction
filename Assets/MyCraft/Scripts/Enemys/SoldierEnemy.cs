using UnityEngine;

public class SoldierEnemy : BaseEnemy
{
    private void Start()
    {
        Deffence = 5;
        // �ړ��ƃW�����v�̋@�\��ݒ�
        SetMovement(gameObject.GetComponent<SoldierEnemyMove>());

        // �ߐڍU����ݒ�
        SetAttack(gameObject.GetComponent<SoldierEnemyAttack>());
    }

    private void Update()
    {
        Move(); // �O�i
        Attack();   // �U��
    }
}