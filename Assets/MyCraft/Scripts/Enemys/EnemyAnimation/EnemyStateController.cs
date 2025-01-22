using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateController : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        Walking,
        Attacking,
        Dying
    }

    public EnemyState CurrentState { get; private set; }

    private EnemyAnimatorController _animatorController;

    private void Start()
    {
        _animatorController = GetComponent<EnemyAnimatorController>();
        ChangeState(EnemyState.Idle);
    }

    public void ChangeState(EnemyState newState)
    {
        CurrentState = newState;

        switch (CurrentState)
        {
            case EnemyState.Idle:
                _animatorController.PlayIdle();
                break;
            case EnemyState.Walking:
                _animatorController.PlayWalk();
                break;
            case EnemyState.Attacking:
                _animatorController.PlayAttack();
                break;
            case EnemyState.Dying:
                _animatorController.PlayDie();
                break;
        }
    }
}
