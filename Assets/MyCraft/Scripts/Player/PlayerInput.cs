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
    public bool CanLeftMove { get; private set; }
    public bool CanRightMove { get; private set; }
    public bool CanMoveStop { get; private set; }
    public bool CanJump { get; private set; }
    public bool CanUseSkill { get; private set; }


    private void Start()
    {
        _player = FindFirstObjectByType<PlayerController>();
    }
    public void PlayerControllerInput()
    {
        _player.UpdateInput();
        _player.UpdateAttack();
        // ���E�ړ��̓��͌��m
        CanLeftMove = Input.GetAxis(WalkPadInput) < 0 || Input.GetKey(KeyCode.A);
        CanRightMove = Input.GetAxis(WalkPadInput) > 0 || Input.GetKey(KeyCode.D);

        CanMoveStop= Input.GetAxis(WalkPadInput) == 0 || Input.GetKeyUp(KeyCode.A)||
            Input.GetAxis(WalkPadInput) == 0 || Input.GetKeyUp(KeyCode.D);

        // �W�����v�ƃX�L���̓��͌��m
        CanJump = Input.GetButtonDown(JumpPadInput) || Input.GetKeyDown(KeyCode.Space);
        CanUseSkill = Input.GetButtonDown(SkillPadInput) || Input.GetKeyDown(KeyCode.Q);
    }
}