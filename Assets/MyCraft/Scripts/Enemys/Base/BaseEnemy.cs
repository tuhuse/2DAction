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
    
    public int Defence { get;set; }
    public void SetMovement(BaseEnemyMove move)
    {
        _move = move;
    }
    public void SetJump(BaseEnemyJump jmp)
    {
        _jump = jmp;
    }
    public void SetAttack(BaseEnemyAttack atk)
    {
        _attack = atk;
    }
    public void SetSense(BaseSensePlayer sense)
    {
        _sense = sense;
    }
    public void Move()
    {
        if (_move != null)
        {
            _move.EnemyMove();
        }
       
    }
    public void FollowLeftMove()
    {
        if (_move != null)
        {
            _move.FollowLeftMove();
        }
    }
    public void FollowRightMove()
    {
        if (_move != null)
        {
            _move.FllowRightMove();
        }
    }
    public void Jump()
    {
        if (_jump != null)
        {
            _jump.EnemyJump();
        }
       
    }
    public void Attack()
    {
        if (_attack != null)
        {
            _attack.EnemyAttack();
        }
       
    }
    public void Sense()
    {
        if (_sense != null)
        {
            _sense.FindPlayer();
        }
        
    }
    public abstract void EnemyUpdate();
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
