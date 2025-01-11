using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{
   
    public delegate void CollisionStayEventHandler(Collision2D collision);
    public delegate void TriggerEventHandler(Collider2D collision);
    public delegate void CollisionEnterEventHandler(Collision2D collision);
    public event CollisionStayEventHandler OnPlayerCollisionStay;
    public event TriggerEventHandler OnPlayerTriggerEnter;
    public event CollisionEnterEventHandler OnPlayerCollisionEnter;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnPlayerCollisionEnter.Invoke(collision);   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnPlayerTriggerEnter.Invoke(collision);
    }

}
