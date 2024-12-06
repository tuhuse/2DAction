using UnityEngine;

public class GetInputManager : MonoBehaviour
{
    public string WalkPadInput => "Horizontal"; // デフォルト設定の軸名を使用
    public string JumpPadInput => "Jump";      // デフォルト設定のボタン名
    public string AttackPadInput => "Fire1";   // デフォルト設定のボタン名
    public string SkillPadInput => "Fire2";    // デフォルト設定のボタン名

    public static GetInputManager Instance { get; private set; }

    public bool CanLeftMove { get; private set; }
    public bool CanRightMove { get; private set; }
    public bool CanJump { get; private set; }
    public bool CanUseSkill { get; private set; }

    private void Awake()
    {
        // シングルトンの設定
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーン間で保持
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // 左右移動の入力検知
        CanLeftMove = Input.GetAxis(WalkPadInput) < 0 || Input.GetKey(KeyCode.A);
        CanRightMove = Input.GetAxis(WalkPadInput) > 0 || Input.GetKey(KeyCode.D);

        // ジャンプとスキルの入力検知
        CanJump = Input.GetButtonDown(JumpPadInput) || Input.GetKeyDown(KeyCode.Space);
        CanUseSkill = Input.GetButtonDown(SkillPadInput) || Input.GetKeyDown(KeyCode.Q);
    }
}
