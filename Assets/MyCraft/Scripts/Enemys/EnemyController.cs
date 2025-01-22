using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyStateController _stateManager;
    private EnemyAnimatorController _animatorController;
    private Rigidbody2D _rb;

    [SerializeField] private float walkSpeed = 2f;

    private void Start()
    {
        _stateManager = GetComponent<EnemyStateController>();
        _animatorController = GetComponent<EnemyAnimatorController>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_stateManager.CurrentState == EnemyStateController.EnemyState.Walking)
        {
            Walk();
        }
    }

    private void Walk()
    {
        _rb.velocity = new Vector2(walkSpeed, _rb.velocity.y);
        _animatorController.SetMovementSpeed(walkSpeed);
    }

    public void Attack()
    {
        _stateManager.ChangeState(EnemyStateController.EnemyState.Attacking);
    }

    public void Die()
    {
        _stateManager.ChangeState(EnemyStateController.EnemyState.Dying);
        _rb.velocity = Vector2.zero; // “®‚«‚ð’âŽ~
    }
}
