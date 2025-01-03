using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    protected BaseEnemyMove _movement;
    protected BaseEnemyJump _jump;
    protected BaseEnemyAttack _attack;

    public void SetMovement(BaseEnemyMove move) => _movement = move;
    public void SetJump(BaseEnemyJump jmp) => _jump = jmp;
    public void SetAttack(BaseEnemyAttack atk) => _attack = atk;

    public void Move() => _movement?.EnemyMove();
    public void Jump() => _jump?.EnemyJump();
    public void Attack() => _attack?.EnemyAttack();
}
