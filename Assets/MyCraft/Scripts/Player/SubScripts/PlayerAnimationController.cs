using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController :MonoBehaviour
{
   [SerializeField] private Player _player;
    private Animator _playerAnimator;
    //[SerializeField] private RuntimeAnimatorController _skillAnimator;
    
   private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        PlayerInput playerInput = FindAnyObjectByType<PlayerInput>();
        // イベントに応じた動作を登録
        playerInput.HandleMove += HandleMovement;
        playerInput.HandleJump += HandleJump;
        playerInput.HandleAttack += HandleAttack;
        playerInput.HandleStop += HandleStop;
    }

    private void HandleMovement(Vector2 direction)
    {
        _playerAnimator.SetBool("Walk", true);
        // 移動処理
    }

    private void HandleJump()
    {
        _playerAnimator.SetBool("Walk", false);
        _playerAnimator.SetTrigger("Jump");

        // ジャンプ処理
    }

    private void HandleAttack()
    {
        if (_player.DistanceEnemy.CanAttack)
        {
            _playerAnimator.SetBool("Walk", false);
            _playerAnimator.SetTrigger("Attack");
        }
      
      
        // 攻撃処理
    }
    private void HandleStop()
    {
        _playerAnimator.SetBool("Walk", false);
    }
}
