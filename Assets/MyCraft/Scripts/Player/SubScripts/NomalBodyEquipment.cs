using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalBodyEquipment : BaseBodyEquipment
{
  
    private const int MAX_JUMP_COUNT = 2;
    private int _currentJumpCount = 0;
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _playerBoxCollider = GetComponent<BoxCollider2D>();
        Deffence = 10;

    }


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
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            IsJump = false;
            _currentJumpCount = 0;
        }
    }

   
}
