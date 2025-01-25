using System;
using UnityEditor.Recorder.Input;
using UnityEngine;
/// <summary>
/// プレイヤーのインプット読み取り
/// </summary>
public class PlayerInput : BaseUpdatable
{
    public event Action<Vector2> OnMove;  // 移動入力イベント
    public event Action OnJump;          // ジャンプ入力イベント
    public event Action OnAttack;        // 攻撃入力イベント
    public event Action OnUseSkill;      // スキル使用イベント

    public string WalkPadInput => "Horizontal"; // デフォルト設定の軸名を使用
    public string JumpPadInput => "Jump";      // デフォルト設定のボタン名
    public string SkillPadInput => "Fire2";    // デフォルト設定のボタン名
    public bool CanLeftMove => /*Input.GetAxis(WalkPadInput) < 0 ||*/ Input.GetKey(KeyCode.A);
    public bool CanRightMove =>/*Input.GetAxis(WalkPadInput)>0||*/ Input.GetKey(KeyCode.D);
    public bool CanJump => Input.GetButtonDown(JumpPadInput) || Input.GetKeyDown(KeyCode.Space);

    public override void OnUpdate()
    {
        HandleMovementInput();
        HandleActionInput();
    }
    private void HandleMovementInput()
    {
      
        if (CanLeftMove)
        {
            OnMove?.Invoke(new Vector2(-1, 0));
        }else if (CanRightMove)
        {
            OnMove?.Invoke(new Vector2(1, 0));
        }
    }

    private void HandleActionInput()
    {
        if (CanJump)
        {
            OnJump?.Invoke();
        }
      
        OnAttack?.Invoke();
    }
    

   
}
