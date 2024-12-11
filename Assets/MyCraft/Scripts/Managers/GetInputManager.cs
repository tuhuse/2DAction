using UnityEngine;


public class GetInputManager : MonoBehaviour
{

    private AnimationInput _animationInput = default;
    private PlayerInput _playerInput = default;
    private void Start()
    {
        _animationInput = GetComponent<AnimationInput>();
        _playerInput = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        _animationInput.AnimationControllerInput();
        _playerInput.PlayerControllerInput();
    }

}
