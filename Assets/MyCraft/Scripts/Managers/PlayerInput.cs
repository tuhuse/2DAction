using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerController _player;
    public string WalkPadInput => "Horizontal"; // デフォルト設定の軸名を使用
    public string JumpPadInput => "Jump";      // デフォルト設定のボタン名
    public string AttackPadInput => "Fire1";   // デフォルト設定のボタン名
    public string SkillPadInput => "Fire2";    // デフォルト設定のボタン名
    public bool CanLeftMove { get; private set; }
    public bool CanRightMove { get; private set; }
    public bool CanJump { get; private set; }
    public bool CanUseSkill { get; private set; }


    private void Start()
    {
        _player = FindFirstObjectByType<PlayerController>();
    }
    public void PlayerControllerInput()
    {
        _player.UpdateInput();
        // 左右移動の入力検知
        CanLeftMove = Input.GetAxis(WalkPadInput) < 0 || Input.GetKey(KeyCode.A);
        CanRightMove = Input.GetAxis(WalkPadInput) > 0 || Input.GetKey(KeyCode.D);

        // ジャンプとスキルの入力検知
        CanJump = Input.GetButtonDown(JumpPadInput) || Input.GetKeyDown(KeyCode.Space);
        CanUseSkill = Input.GetButtonDown(SkillPadInput) || Input.GetKeyDown(KeyCode.Q);
    }
}
