using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSensePlayer : MonoBehaviour
{
    [SerializeField] protected Transform _player;
    protected const float MAX_DISTANCE_PLAYER=10f;
    
    public bool IsRightFindPlayer { get; set; } = false;
    public bool IsLeftFindPlayer { get; set; } = false;

    public abstract void FindPlayer();
}
