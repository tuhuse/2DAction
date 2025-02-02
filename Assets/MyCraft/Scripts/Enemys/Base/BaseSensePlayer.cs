using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSensePlayer : MonoBehaviour
{
    protected Transform _player;
    protected const float MAX_DISTANCE_PLAYER=20f;
    
    public bool IsRightFindPlayer { get; set; } = false;
    public bool IsLeftFindPlayer { get; set; } = false;
    public bool IsAttack { get; set; } = false;
    public abstract void FindPlayer();
    private void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }
}
