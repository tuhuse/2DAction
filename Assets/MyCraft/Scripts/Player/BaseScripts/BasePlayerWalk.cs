using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePlayerWalk : MonoBehaviour
{
    public float WalkSpeed { get; set; } = 10f;
    public abstract void RightWalK();
    public abstract void LeftWalK();
}