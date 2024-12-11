using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationInput : MonoBehaviour
{
    private PlayerAnimationController _playerAnimator;
    public string WalkPadInput => "Horizontal"; // �f�t�H���g�ݒ�̎������g�p
    public string JumpPadInput => "Jump";      // �f�t�H���g�ݒ�̃{�^����
    public string SkillPadInput => "Fire2";    // �f�t�H���g�ݒ�̃{�^����

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
        //�A�j���[�V�����̑J�ڂ̓��͌��m
        IsWalkAnimation = Input.GetAxis(WalkPadInput) > 0 || Input.GetAxis(WalkPadInput) < 0
                       || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D);
        IsJumpAnimation = Input.GetButtonDown(JumpPadInput) || Input.GetKeyDown(KeyCode.Space);
        IsStayAnimation= /*Input.GetAxis(WalkPadInput) == 0||*/ Input.GetKeyDown(KeyCode.Q);
    }
}
