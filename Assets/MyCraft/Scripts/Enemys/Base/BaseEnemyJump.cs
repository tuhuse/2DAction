using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemyJump : MonoBehaviour
{
    private const float JUMP_FORCE = 5.0f;

    public float JumpForce { get; set; } = JUMP_FORCE;


    public abstract void EnemyJump();
    
}
