
public class FollowStandEnemy : BaseEnemy
{
  

    // Start is called before the first frame update
    void Start()
    {
        Defence = 15;
        // �ߐڍU����ݒ�
        SetAttack(gameObject.GetComponent<StandEnemyAttack>());
        //�v���C���[�����m����
        SetSense(gameObject.GetComponent<StandSensePlayer>());
    }
   

    public override void EnemyUpdate()
    {
        if (_sense.IsAttack)
        {
            Attack();
            //_enemyStateController.ChangeState(EnemyStateController.EnemyState.Attacking);
        }
        Sense();
    }
}
