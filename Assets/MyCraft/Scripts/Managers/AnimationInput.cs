using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationInput : MonoBehaviour
{
    private PlayerAnimationController _playerAnimator;
    public string WalkPadInput => "Horizontal"; // デフォルト設定の軸名を使用
    public string JumpPadInput => "Jump";      // デフォルト設定のボタン名
    public string SkillPadInput => "Fire2";    // デフォルト設定のボタン名

    public bool IsWalkAnimation { get; private set; }
    public bool IsRunAnimation { get; private set; }
    public bool IsJumpAnimation { get; private set; }
    public bool IsStayAnimation { get; private set; }
    private void Start()
    {
        _playerAnimator = FindFirstObjectByType<PlayerAnimationController>();
    }
    public void AnimationControllerInput()
    {
        _playerAnimator.UpdateAnimation();
        //アニメーションの遷移の入力検知
        IsWalkAnimation = Input.GetAxis(WalkPadInput) > 0 || Input.GetAxis(WalkPadInput) < 0
                       || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D);
        IsJumpAnimation = Input.GetButtonDown(JumpPadInput) || Input.GetKeyDown(KeyCode.Space);
        IsStayAnimation= /*Input.GetAxis(WalkPadInput) == 0||*/ Input.GetKeyDown(KeyCode.Q);
    }
}
