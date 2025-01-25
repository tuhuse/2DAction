using System;
using UnityEditor.Recorder.Input;
using UnityEngine;
/// <summary>
/// �v���C���[�̃C���v�b�g�ǂݎ��
/// </summary>
public class PlayerInput : BaseUpdatable
{
    public event Action<Vector2> OnMove;  // �ړ����̓C�x���g
    public event Action OnJump;          // �W�����v���̓C�x���g
    public event Action OnAttack;        // �U�����̓C�x���g
    public event Action OnUseSkill;      // �X�L���g�p�C�x���g

    public string WalkPadInput => "Horizontal"; // �f�t�H���g�ݒ�̎������g�p
    public string JumpPadInput => "Jump";      // �f�t�H���g�ݒ�̃{�^����
    public string SkillPadInput => "Fire2";    // �f�t�H���g�ݒ�̃{�^����
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
