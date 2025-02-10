using System;
using UnityEngine;
/// <summary>
/// プレイヤーのインプット読み取り
/// </summary>
public class PlayerInput : BaseUpdatable
{
    private event Action<Vector2> _handleMove;  // 移動入力イベント
    private event Action _handleJump;          // ジャンプ入力イベント
    private event Action _handleAttack;        // 攻撃入力イベント
    private event Action _handleStop;      // ストップイベント

    public string WalkPadInput => "Horizontal"; // デフォルト設定の軸名を使用
    public string JumpPadInput => "Jump";      // デフォルト設定のボタン名
    public string SkillPadInput => "Fire2";    // デフォルト設定のボタン名
    public bool CanLeftMove => /*Input.GetAxis(WalkPadInput) < 0 ||*/ Input.GetKey(KeyCode.A);
    public bool CanRightMove =>/*Input.GetAxis(WalkPadInput)>0||*/ Input.GetKey(KeyCode.D);
    public bool CanStopMove =>/*Input.GetAxis(WalkPadInput)>0||*/ Input.GetKeyUp(KeyCode.D)|| Input.GetKeyUp(KeyCode.A);
    public bool CanJump => Input.GetButtonDown(JumpPadInput) || Input.GetKeyDown(KeyCode.Space);
    /// <summary>
    /// プレイヤー移動
    /// </summary>
    public event Action<Vector2> HandleMove
    {
        add => _handleMove += value;
        remove => _handleMove -= value;
    }
    /// <summary>
    /// プレイヤージャンプ
    /// </summary>
    public event Action HandleJump
    {
        add => _handleJump += value;
        remove => _handleJump -= value;
    }
    /// <summary>
     /// プレイヤー攻撃
     /// </summary>
    public event Action HandleAttack
    {
        add => _handleAttack += value;
        remove => _handleAttack -= value;
    } /// <summary>
     /// プレイヤーストップ
     /// </summary>
    public event Action HandleStop
    {
        add => _handleStop += value;
        remove => _handleStop -= value;
    }

    public override void OnUpdate()
    {
        HandleMovementInput();
        HandleActionInput();
    }
    private void HandleMovementInput()
    {

        if (CanLeftMove)
        {
            if (_handleMove == null)
            {
                return;
            }
            _handleMove.Invoke(Vector2.left);
        }
        else if (CanRightMove)
        {
            if (_handleMove == null)
            {
                return;
            }
            _handleMove.Invoke(Vector2.right);
        }
        else
        {
            if (_handleStop == null)
            {
                return;
               
            }
            _handleStop.Invoke();
        }
    }

    private void HandleActionInput()
    {
        if (CanJump)
        {
            if (_handleJump == null)
            {
                return;
            }
            _handleJump.Invoke();
        }
        if (_handleAttack == null)
        {
            return;
        }
        _handleAttack.Invoke();
    }



}
