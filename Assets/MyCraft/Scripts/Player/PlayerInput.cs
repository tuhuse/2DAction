using System;
using UnityEditor.Recorder.Input;
using UnityEngine;
/// <summary>
/// �v���C���[�̃C���v�b�g�ǂݎ��
/// </summary>
public class PlayerInput : BaseUpdatable
{
    private event Action<Vector2> _handleMove;  // �ړ����̓C�x���g
    private event Action _handleJump;          // �W�����v���̓C�x���g
    private event Action _handleAttack;        // �U�����̓C�x���g
    private event Action OnUseSkill;      // �X�L���g�p�C�x���g

    public string WalkPadInput => "Horizontal"; // �f�t�H���g�ݒ�̎������g�p
    public string JumpPadInput => "Jump";      // �f�t�H���g�ݒ�̃{�^����
    public string SkillPadInput => "Fire2";    // �f�t�H���g�ݒ�̃{�^����
    public bool CanLeftMove => /*Input.GetAxis(WalkPadInput) < 0 ||*/ Input.GetKey(KeyCode.A);
    public bool CanRightMove =>/*Input.GetAxis(WalkPadInput)>0||*/ Input.GetKey(KeyCode.D);
    public bool CanJump => Input.GetButtonDown(JumpPadInput) || Input.GetKeyDown(KeyCode.Space);
    /// <summary>
    /// �v���C���[�ړ�
    /// </summary>
    public event Action<Vector2> HandleMove
    {
        add => _handleMove += value;
        remove => _handleMove -= value;
    }
    /// <summary>
    /// �v���C���[�W�����v
    /// </summary>
    public event Action HandleJump
    {
        add => _handleJump += value;
        remove => _handleJump -= value;
    }
    /// <summary>
     /// �v���C���[�U��
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
