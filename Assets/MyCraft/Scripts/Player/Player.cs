using UnityEngine;

public class Player : MonoBehaviour
{
    private BasePlayerWalk _playerWalk;
    private BasePlayerJump _playerJump;
    private BasePlayerAttack _playerAttack;

    private void Start()
    {
        // �K�v�ȃR���|�[�l���g���擾
        _playerWalk = GetComponent<NomalWalk>();
        _playerJump = GetComponent<NomalJump>();
        _playerAttack = GetComponent<SordAttack>();

        // �R���|�[�l���g�����݂��Ȃ��ꍇ�̌x��
        if (_playerWalk == null) Debug.LogWarning("BasePlayerWalk component is missing!");
        if (_playerJump == null) Debug.LogWarning("BasePlayerJump component is missing!");
        if (_playerAttack == null) Debug.LogWarning("BasePlayerAttack component is missing!");
    }

    public void RightWalk()
    {
        if (_playerWalk != null)
        {
            _playerWalk.RightWalk();
        }
    }

    public void LeftWalk()
    {
        if (_playerWalk != null)
        {
            _playerWalk.LeftWalk();
        }
    }

    public void Jump()
    {
        if (_playerJump != null)
        {
            _playerJump.Jump();
        }
    }

    public void Attack()
    {
        if (_playerAttack != null)
        {
            _playerAttack.TryAttack();
        }
    }
}
