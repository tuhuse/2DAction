using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController :MonoBehaviour
{

    private Animator _playerAnimator;
    private AnimationInput _animationInput;
    [SerializeField] private RuntimeAnimatorController _stayAnimator;
    [SerializeField] private RuntimeAnimatorController _walkAnimator;
    [SerializeField] private RuntimeAnimatorController _runAnimator;
    [SerializeField] private RuntimeAnimatorController _attackAnimator;
    [SerializeField] private RuntimeAnimatorController _jumpAnimator;
    [SerializeField] private RuntimeAnimatorController _deathAnimator;
    [SerializeField] private RuntimeAnimatorController _winnerAnimator;
    //[SerializeField] private RuntimeAnimatorController _skillAnimator;
    
   private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        _animationInput = FindFirstObjectByType<AnimationInput>();
    }

    public void UpdateAnimation()
    {
        if (_animationInput.IsWalkAnimation)
        {
            _playerAnimator.runtimeAnimatorController = _walkAnimator;
        }
        if (_animationInput.IsJumpAnimation)
        {
            _playerAnimator.runtimeAnimatorController = _jumpAnimator;
        }
        if (_animationInput.IsStayAnimation)
        {
            _playerAnimator.runtimeAnimatorController = _stayAnimator;
        }
    }
}
