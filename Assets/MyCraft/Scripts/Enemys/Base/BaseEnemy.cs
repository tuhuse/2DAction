using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    protected BaseEnemyMove _move;
    protected BaseEnemyJump _jump;
    protected BaseEnemyAttack _attack;
    protected BaseSensePlayer _sense;

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
}
