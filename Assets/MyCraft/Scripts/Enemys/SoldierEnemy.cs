using UnityEngine;

public class SoldierEnemy : BaseEnemy
{
    

    private void Start()
    {
        Defence = 5;
        // �ړ��ƃW�����v�̋@�\��ݒ�
        SetMovement(gameObject.GetComponent<SoldierEnemyMove>());

        // �ߐڍU����ݒ�
        SetAttack(gameObject.GetComponent<SoldierEnemyAttack>());
        _enemyStateController.ChangeState(EnemyStateController.EnemyState.Walking);
    }
    public override void EnemyUpdate()
    {
        Move(); // �O�i
        Attack();   // �U��
    }
}