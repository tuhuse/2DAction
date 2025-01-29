using System;
using UnityEditor.Recorder.Input;
using UnityEngine;
/// <summary>
/// プレイヤーのインプット読み取り
/// </summary>
public class PlayerInput : BaseUpdatable
{
    private event Action<Vector2> _handleMove;  // 移動入力イベント
    private event Action _handleJump;          // ジャンプ入力イベント
    private event Action _handleAttack;        // 攻撃入力イベント
    private event Action OnUseSkill;      // スキル使用イベント

    public string WalkPadInput => "Horizontal"; // デフォルト設定の軸名を使用
    public string JumpPadInput => "Jump";      // デフォルト設定のボタン名
    public string SkillPadInput => "Fire2";    // デフォルト設定のボタン名
    public bool CanLeftMove => /*Input.GetAxis(WalkPadInput) < 0 ||*/ Input.GetKey(KeyCode.A);
    public bool CanRightMove =>/*Input.GetAxis(WalkPadInput)>0||*/ Input.GetKey(KeyCode.D);
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
            _handleMove?.Invoke(new Vector2(-1, 0));
        }
        else if (CanRightMove)
        {
            _handleMove?.Invoke(new Vector2(1, 0));
        }
    }

    private void HandleActionInput()
    {
        if (CanJump)
        {
            _handleJump?.Invoke();
        }

        _handleAttack?.Invoke();
    }



}
