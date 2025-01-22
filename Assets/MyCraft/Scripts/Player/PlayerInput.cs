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
    public bool CanLeftMove => /*Input.GetAxis(WalkPadInput) < 0 ||*/ Input.GetKey(KeyCode.A);
    public bool CanRightMove =>/*Input.GetAxis(WalkPadInput)>0||*/ Input.GetKey(KeyCode.D);
    public bool CanJump =>Input.GetButtonDown(JumpPadInput)|| Input.GetKeyDown(KeyCode.Space);
    public bool CanUseSkill => Input.GetKeyDown(KeyCode.P);


    private void Start()
    {
        _player = FindFirstObjectByType<PlayerController>();
    }
    public void PlayerControllerInput()
    {
        _player.UpdateInput();
        _player.UpdateAttack();
       
    }
}
