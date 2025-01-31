using System;
using UnityEngine;
/// <summary>
/// プレイヤーの入力を処理する
/// </summary>
public class PlayerController : MonoBehaviour
{
    public PlayerStatus PlayerStatus { get; private set; } = new PlayerStatus();
    private Player _player;
    private void Start()
    {
        _player = GetComponent<Player>();
        PlayerInput playerInput = FindAnyObjectByType<PlayerInput>();

        // イベントに応じた動作を登録
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
    private void HandleStop()
    {
        _player.MoveStop();
    }


}
