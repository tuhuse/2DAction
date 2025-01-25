using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player _player;
    private void Start()
    {
        _player = GetComponent<Player>();
        PlayerInput playerInput = FindAnyObjectByType<PlayerInput>();

        // �C�x���g�ɉ����������o�^
        playerInput.OnMove += HandleMovement;
        playerInput.OnJump += HandleJump;
        playerInput.OnAttack += HandleAttack;
       
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
        else
        {
            _player.MoveStop();
        }

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

    
}
