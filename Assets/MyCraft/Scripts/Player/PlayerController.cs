using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    
    public float JumpPower { get; set; } = 5f;
    public float WalkSpeed { get; set; } = 10f;

   public float WalkPadInput =>Input.GetAxis("Lstick");
    public string JumpPadInput => "Jump";
   public string AttackPadInput => "Attack";
   public string SkillPadInput => "Skill";


}
