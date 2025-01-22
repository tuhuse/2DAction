using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerController _player;
    public string WalkPadInput => "Horizontal"; // �f�t�H���g�ݒ�̎������g�p
    public string JumpPadInput => "Jump";      // �f�t�H���g�ݒ�̃{�^����
    public string AttackPadInput => "Fire1";   // �f�t�H���g�ݒ�̃{�^����
    public string SkillPadInput => "Fire2";    // �f�t�H���g�ݒ�̃{�^����
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
