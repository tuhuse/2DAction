using UnityEngine;

public class Walk : MonoBehaviour, IWalk
{
    // �ړ����x
    public float WalkSpeed { get; set; } = 10f;

    // Rigidbody2D�̎Q��
    private Rigidbody2D _playerRigidbody = null;

    void Start()
    {
        // Rigidbody2D���擾
        _playerRigidbody = GetComponent<Rigidbody2D>();
        if (_playerRigidbody == null)
        {
            Debug.LogError("Rigidbody2D���A�^�b�`����Ă��܂���I");
        }
    }

    public virtual void PlayerAction()
    {
        // Rigidbody2D��null�łȂ��ꍇ�Ɉړ����������s
        if (_playerRigidbody != null)
        {
            _playerRigidbody.velocity = new Vector2(WalkSpeed, _playerRigidbody.velocity.y);
        }
    }
}
