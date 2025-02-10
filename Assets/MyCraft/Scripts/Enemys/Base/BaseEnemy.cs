using UnityEngine;

/// <summary>
/// “G
/// </summary>
public abstract class BaseEnemy : MonoBehaviour
{

    //protected EnemyStateController _enemyStateController;
    protected BaseEnemyMove _move;
    protected BaseEnemyJump _jump;
    protected BaseEnemyAttack _attack;
    protected BaseSensePlayer _sense;
    public int Defence { get; set; }
    public void SetMovement(BaseEnemyMove move)
    {
        if (move == null)
        {
            return;
        }
        _move = move;
    }
    public void SetJump(BaseEnemyJump jmp)
    {
        if (jmp == null)
        {
            return;
        }
        _jump = jmp;
    }
    public void SetAttack(BaseEnemyAttack atk)
    {
        if (atk == null)
        {
            return;
        }
        _attack = atk;
    }
    public void SetSense(BaseSensePlayer sense)
    {
        if (sense == null)
        {
            return;
        }
        _sense = sense;
    }
    public void Move()
    {
        if (_move == null)
        {
            return;
        }
        _move.EnemyMove();

    }
    public void FollowLeftMove()
    {
        if (_move == null)
        {
            return;
        }
        _move.FollowLeftMove();

    }
    public void FollowRightMove()
    {
        if (_move == null)
        {
            return;
        }
        _move.FllowRightMove();

    }
    public void Jump()
    {
        if (_jump == null)
        {
            return;
        }
        _jump.EnemyJump();


    }
    public void Attack()
    {
        if (_attack == null)
        {
            return;
        }
        _attack.EnemyAttack();


    }
    public void Sense()
    {
        if (_sense == null)
        {
            return;
        }
        _sense.FindPlayer();


    }
    /// <summary>
    /// “G‚ÌƒAƒbƒvƒf[ƒgˆ—
    /// /// </summary>
    public abstract void EnemyUpdate();
    /// <summary>
    /// “G‚ğˆêŠ‡ŠÇ—‚·‚é‚½‚ß‚ÉŠi”[‚·‚éˆ—
    /// </summary>
    private void OnEnable()
    {

        EnemyController.Instance.EnemyRegister(this);
        //_enemyStateController = GetComponent<EnemyStateController>();
    }
    /// <summary>
    /// “G‚ğˆêŠ‡ŠÇ—‚ğ‰ğœ‚·‚é‚½‚ß‚ÉŠi”[‚·‚éˆ—
    /// </summary>
    private void OnDisable()
    {
        EnemyController.Instance.EnemyUnregister(this);
    }

}
