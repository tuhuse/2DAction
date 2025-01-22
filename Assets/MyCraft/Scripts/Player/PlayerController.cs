using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player _player;
    private PlayerInput _playerInput;

    void Start()
    {
        _player = GetComponent<Player>();
        _playerInput = FindFirstObjectByType<PlayerInput>();

    }


    public void UpdateInput()
    {

        if (_playerInput.CanLeftMove)
        {
            _player.LeftWalk();
        }
        else if(_playerInput.CanRightMove)
        {
            _player.RightWalk();
        }
        else
        {
            _player.MoveStop();
        }

        
        if (_playerInput.CanJump)
        {
            _player.Jump();
        }


        if (_playerInput.CanUseSkill)
        {

        }

    }
    public void UpdateAttack()
    {
        _player.Attack();
    }


}
