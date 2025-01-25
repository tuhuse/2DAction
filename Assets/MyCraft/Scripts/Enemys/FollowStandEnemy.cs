
public class FollowStandEnemy : BaseEnemy
{
  

    // Start is called before the first frame update
    void Start()
    {
        Deffence = 15;
        // 近接攻撃を設定
        SetAttack(gameObject.GetComponent<StandEnemyAttack>());
        //プレイヤーを感知する
        SetSense(gameObject.GetComponent<StandSensePlayer>());
    }
   

    public override void EnemyUpadate()
    {
        if (_sense.IsAttack)
        {
            Attack();
            _enemyStateController.ChangeState(EnemyStateController.EnemyState.Attacking);
        }
        Sense();
    }
}
