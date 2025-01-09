using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBodyEquipment : MonoBehaviour
{
    protected Rigidbody2D _playerRigidbody = default;
    protected BoxCollider2D _playerBoxCollider = default;
    protected float JumpPower { get; set; } = 5f;
    protected bool IsJump { get; set; } = false;
    public float WalkSpeed { get; set; } = 10f;

    public int Deffence { get; set; }
    public abstract void RightWalk();
    public abstract void LeftWalk();

    public abstract void Jump();
    
}
