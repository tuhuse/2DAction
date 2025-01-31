using System;
using UnityEngine;
/// <summary>
/// �v���C���[�̓��͂���������
/// </summary>
public class PlayerController : MonoBehaviour
{
    public PlayerStatus PlayerStatus { get; private set; } = new PlayerStatus();
    private Player _player;
    private void Start()
    {
        _player = GetComponent<Player>();
        PlayerInput playerInput = FindAnyObjectByType<PlayerInput>();

        // �C�x���g�ɉ����������o�^
        playerInput.HandleMove += HandleMovement;
        playerInput.HandleJump += HandleJump;
        playerInput.HandleAttack += HandleAttack;
        playerInput.HandleStop += HandleStop;
    }

   
    private void HandleMovement(Vector2 direction)
    {
        if (direction.x < 0)
        {
            _player.LeftWalk();
        }
        else if (direction.x > 0)
        {
            _player.RightWalk();
        }
        //else
        //{
        //    _player.MoveStop();
        //}

        // �ړ�����
    }

    private void HandleJump()
    {
        _player.Jump(); 
        // �W�����v����
    }

    private void HandleAttack()
    {
        _player.Attack();
        // �U������
    }
    private void HandleStop()
    {
        _player.MoveStop();
    }


}
