using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BasePlayerJump : MonoBehaviour
{
    public float JumpPower { get; set; } = 5f;
    public bool IsJump { get; set; } = false;


  
    public abstract void Jump();
}
