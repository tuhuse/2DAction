using System;
using UnityEngine;
/// <summary>
/// �v���C���[�̃C���v�b�g�ǂݎ��
/// </summary>
public class PlayerInput : BaseUpdatable
{
    private event Action<Vector2> _handleMove;  // �ړ����̓C�x���g
    private event Action _handleJump;          // �W�����v���̓C�x���g
    private event Action _handleAttack;        // �U�����̓C�x���g
    private event Action _handleStop;      // �X�g�b�v�C�x���g

    public string WalkPadInput => "Horizontal"; // �f�t�H���g�ݒ�̎������g�p
    public string JumpPadInput => "Jump";      // �f�t�H���g�ݒ�̃{�^����
    public string SkillPadInput => "Fire2";    // �f�t�H���g�ݒ�̃{�^����
    public bool CanLeftMove => /*Input.GetAxis(WalkPadInput) < 0 ||*/ Input.GetKey(KeyCode.A);
    public bool CanRightMove =>/*Input.GetAxis(WalkPadInput)>0||*/ Input.GetKey(KeyCode.D);
    public bool CanStopMove =>/*Input.GetAxis(WalkPadInput)>0||*/ Input.GetKeyUp(KeyCode.D)|| Input.GetKeyUp(KeyCode.A);
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
    } /// <summary>
     /// �v���C���[�X�g�b�v
     /// </summary>
    public event Action HandleStop
    {
        add => _handleStop += value;
        remove => _handleStop -= value;
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
            if (_handleMove == null)
            {
                return;
            }
            _handleMove.Invoke(Vector2.left);
        }
        else if (CanRightMove)
        {
            if (_handleMove == null)
            {
                return;
            }
            _handleMove.Invoke(Vector2.right);
        }
        else
        {
            if (_handleStop == null)
            {
                return;
               
            }
            _handleStop.Invoke();
        }
    }

    private void HandleActionInput()
    {
        if (CanJump)
        {
            if (_handleJump == null)
            {
                return;
            }
            _handleJump.Invoke();
        }
        if (_handleAttack == null)
        {
            return;
        }
        _handleAttack.Invoke();
    }



}
