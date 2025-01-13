using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalBodyEquipment : BaseBodyEquipment
{
  
    private const int MAX_JUMP_COUNT = 2;
    private int _currentJumpCount = 0;
   protected override void  Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerRigidbody =_player.GetComponent<Rigidbody2D>();
        _playerBoxCollider = _player.GetComponent<BoxCollider2D>();
        // プレイヤーの衝突検知スクリプトを取得
        PlayerCollisionDetector collisionDetector = _player.GetComponent<PlayerCollisionDetector>();
        if (collisionDetector != null)
        {
            collisionDetector.OnPlayerCollisionStay += HandleCollisionStay;
        }

        SetEqueipment();
    }


    /// <summary>
    /// 通常装備のジャンプ
    /// </summary>
    public override void Jump()
    {
        if (!IsJump)
        {
            if (_currentJumpCount < MAX_JUMP_COUNT)
            {
                _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, JumpPower);
                _currentJumpCount++;
                IsJump = true;
            }
        }

    }
    public override void RightWalk()
    {
        _playerRigidbody.velocity = new Vector2(WalkSpeed, _playerRigidbody.velocity.y);
    }

    public override void LeftWalk()
    {
        _playerRigidbody.velocity = new Vector2(-WalkSpeed, _playerRigidbody.velocity.y);
    }

    private void HandleCollisionStay(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            IsJump = false;
            _currentJumpCount = 0;
        }
    }

    
}
