
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

    // Update is called once per frame
    void Update()
    {
        if (_sense.IsAttack)
        {
            Attack();
        }
        Sense();
    }
}
