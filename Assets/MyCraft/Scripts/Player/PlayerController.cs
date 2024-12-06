using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player _player;
    private GetInputManager _playerInput;
    void Start()
    {
        _player = GetComponent<Player>();
        _playerInput = GetInputManager.Instance;
    }

    void Update()
    {
        UpdateInput();
    }
    private void UpdateInput()
    {
        if (_playerInput.CanLeftMove)
        {
           
            _player.LeftWalk();
        }
         if (_playerInput.CanRightMove)
        {
            _player.RightWalk();
        }

        if (_playerInput.CanJump)
        {
            _player.Jump();
        }
        if (_playerInput.CanUseSkill)
        {

        }
    }

}
