
public class FollowStandEnemy : BaseEnemy
{
    // Start is called before the first frame update
    void Start()
    {
        Deffence = 15;
        // �ߐڍU����ݒ�
        SetAttack(gameObject.GetComponent<StandEnemyAttack>());
        //�v���C���[�����m����
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
