using UnityEngine;

public class GetInputManager : MonoBehaviour
{
    public string WalkPadInput => "Horizontal"; // �f�t�H���g�ݒ�̎������g�p
    public string JumpPadInput => "Jump";      // �f�t�H���g�ݒ�̃{�^����
    public string AttackPadInput => "Fire1";   // �f�t�H���g�ݒ�̃{�^����
    public string SkillPadInput => "Fire2";    // �f�t�H���g�ݒ�̃{�^����

    public static GetInputManager Instance { get; private set; }

    public bool CanLeftMove { get; private set; }
    public bool CanRightMove { get; private set; }
    public bool CanJump { get; private set; }
    public bool CanUseSkill { get; private set; }

    private void Awake()
    {
        // �V���O���g���̐ݒ�
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �V�[���Ԃŕێ�
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // ���E�ړ��̓��͌��m
        CanLeftMove = Input.GetAxis(WalkPadInput) < 0 || Input.GetKey(KeyCode.A);
        CanRightMove = Input.GetAxis(WalkPadInput) > 0 || Input.GetKey(KeyCode.D);

        // �W�����v�ƃX�L���̓��͌��m
        CanJump = Input.GetButtonDown(JumpPadInput) || Input.GetKeyDown(KeyCode.Space);
        CanUseSkill = Input.GetButtonDown(SkillPadInput) || Input.GetKeyDown(KeyCode.Q);
    }
}
