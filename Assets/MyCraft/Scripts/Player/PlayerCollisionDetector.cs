using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{
   
    public delegate void CollisionEventHandler(Collision2D collision);
    public delegate void TriggerEventHandler(Collider2D collision);
    public event CollisionEventHandler OnPlayerCollisionStay;
    public event TriggerEventHandler OnPlayerTriggerEnter;
    public static PlayerCollisionDetector Instance { get; private set; }

    private void Awake()
    {
        // �V���O���g���̃C���X�^���X��ݒ�
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // ���̃C���X�^���X������΍폜
        }
        else
        {
            Instance = this; // ���g���C���X�^���X�Ƃ��Đݒ�
            DontDestroyOnLoad(gameObject); // �V�[�����ς���Ă������Ȃ��悤�ɂ���
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
       
            OnPlayerCollisionStay.Invoke(collision); // �Փˏ����C�x���g�Ƃ��Ēʒm
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnPlayerTriggerEnter.Invoke(collision);
    }

}
