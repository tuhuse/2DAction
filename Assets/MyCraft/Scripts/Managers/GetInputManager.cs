using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInputManager : PlayerController
{
    

    public static GetInputManager Instance { get; private set; }


    public bool IsLeftMove { get; private set; } = default;
    public bool IsRightMove { get;private set; } = default;
    public bool IsJump { get; set; } = default;
    public bool IsUseSkill { get; set; } = default;
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
        if (WalkPadInput < 0 || Input.GetKey(KeyCode.A))
        {
            IsLeftMove = true;
        }
        if (WalkPadInput > 0 || Input.GetKey(KeyCode.D))
        {
            IsRightMove = true;
        }
        
    }
    // Update is called once per frame
   private void Update()
    {
        if (Input.GetButtonDown(SkillPadInput) || Input.GetKeyDown(KeyCode.Q))
        {
            IsUseSkill = true;
        }
        if (WalkPadInput == 0||Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D))
        {
            IsLeftMove = false;
            IsRightMove = false;
        }
        if (Input.GetButtonDown(JumpPadInput) || Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
}
