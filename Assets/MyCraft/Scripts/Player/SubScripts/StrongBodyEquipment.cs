using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongBodyEquipment : BaseBodyEquipment
{
    private const int MAX_JUMP_COUNT = 2;
    private int _currentJumpCount = 0;
    protected override void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerRigidbody = _player.GetComponent<Rigidbody2D>();
        _playerBoxCollider = _player.GetComponent<BoxCollider2D>();
        // �v���C���[�̏Փˌ��m�X�N���v�g���擾
        PlayerCollisionDetector collisionDetector = _player.GetComponent<PlayerCollisionDetector>();
        if (collisionDetector != null)
        {
            collisionDetector.OnPlayerCollisionStay += HandleCollisionStay;
        }

        SetEqueipment();
    }
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
        }
    }


}