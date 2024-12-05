using UnityEngine;
/// <summary>
/// ƒWƒƒƒ“ƒv‚ð‚·‚é
/// </summary>
public class PlayerJump : PlayerController,IJump
{
    private GetInputManager _getInput;
    private Rigidbody2D _playerRigidbody = default;


    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _getInput = GetInputManager.Instance;
    }
    private void Update()
    {
        if (_getInput.IsJump)
        {
            Jump();
        }
    }
    public void Jump()
    {
        _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, JumpPower);
    }

}
