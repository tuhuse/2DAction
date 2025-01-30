using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalBodyEquipment : BaseBodyEquipment
{

    private const int MAX_JUMP_COUNT = 2;
    private int _currentJumpCount = 0;
    /// <summary>
    /// ’Êí‘•”õ‚ÌƒWƒƒƒ“ƒv
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

    protected override void HandleCollisionStay(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            IsJump = false;
            _currentJumpCount = 0;
            _playerRigidbody.gravityScale = _equipmentData.InitializeGravityScale;
        }
    }
    protected override void HandleCollisionExit(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            _playerRigidbody.gravityScale = _equipmentData.GravityScale;
        }
    }

}
