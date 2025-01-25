using UnityEngine;

/// <summary>
/// “G
/// </summary>
public abstract class BaseEnemy : MonoBehaviour
{

    protected EnemyStateController _enemyStateController;
    protected BaseEnemyMove _move;
    protected BaseEnemyJump _jump;
    protected BaseEnemyAttack _attack;
    protected BaseSensePlayer _sense;
    
    public int Deffence { get;set; }
    public void SetMovement(BaseEnemyMove move) => _move = move;
    public void SetJump(BaseEnemyJump jmp) => _jump = jmp;
    public void SetAttack(BaseEnemyAttack atk) => _attack = atk;
    public void SetSense(BaseSensePlayer sense) => _sense = sense;
    public void Move() => _move?.EnemyMove();
    public void FollowLeftMove() => _move?.FollowLeftMove();
    public void FollowRightMove() => _move?.FllowRightMove();
    public void Jump() => _jump?.EnemyJump();
    public void Attack() => _attack?.EnemyAttack();
    public void Sense() => _sense?.FindPlayer();
    public abstract void EnemyUpadate();
    private void OnEnable()
    {
            EnemyController.Instance.EnemyRegister(this);
        _enemyStateController = GetComponent<EnemyStateController>();
    }
    private void OnDisable()
    {
            EnemyController.Instance.EnemyUnregister(this);  
    }

}
