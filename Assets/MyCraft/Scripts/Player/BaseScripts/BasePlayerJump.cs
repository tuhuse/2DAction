using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BasePlayerJump : MonoBehaviour
{
    protected float JumpPower { get; set; } = 5f;
    protected bool IsJump { get; set; } = false;


  
    public abstract void Jump();
}
