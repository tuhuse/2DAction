using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemyMove : MonoBehaviour
{
    private const float MOVE_SPEED = 5.0f;    
    protected float MoveSpeed { get; set; } = MOVE_SPEED;
   protected bool IsRightSwitch { get; set; } = false;
    public abstract void EnemyMove();
    public virtual void FollowLeftMove()
    {
        //’Ç”ö‚Ì“G‚ÍŽg‚¤
    }
    public virtual void FllowRightMove()
    {
        //’Ç”ö‚Ì“G‚ÍŽg‚¤
    }
}
