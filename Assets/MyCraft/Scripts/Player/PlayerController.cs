using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player _player;
    private void Start()
    {
        _player = GetComponent<Player>();
        PlayerInput playerInput = FindAnyObjectByType<PlayerInput>();

        // イベントに応じた動作を登録
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

        // 移動処理
    }

    private void HandleJump()
    {
        _player.Jump(); 
        // ジャンプ処理
    }

    private void HandleAttack()
    {
        _player.Attack();
        // 攻撃処理
    }

    
}
