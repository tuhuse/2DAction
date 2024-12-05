using UnityEngine;

public class GetInputManager : MonoBehaviour
{
    public string WalkPadInput => "Lstick";
    public string JumpPadInput => "Jump";
    public string AttackPadInput => "Attack";
    public string SkillPadInput => "Skill";

    public static GetInputManager Instance { get; private set; }


    public bool CanLeftMove { get; private set; } = default;
    public bool CanRightMove { get;private set; } = default;
    public bool CanJump { get; set; } = default;
    public bool CanUseSkill { get; set; } = default;
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
    private void FixedUpdate()
    {
        CanLeftMove = /*Input.GetAxis(WalkPadInput) < 0 ||*/ Input.GetKey(KeyCode.A);

        CanRightMove = /*Input.GetAxis(WalkPadInput) > 0 ||*/ Input.GetKey(KeyCode.D);
        
        
    }
    // Update is called once per frame
   private void Update()
    {
        CanUseSkill = /*Input.GetButtonDown(SkillPadInput) ||*/ Input.GetKeyDown(KeyCode.Q);
       CanJump = /*Input.GetButtonDown(JumpPadInput) ||*/ Input.GetKeyDown(KeyCode.Space);

      

    }
}
