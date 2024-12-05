using UnityEngine;

public class PlayerWalk : PlayerController, IWalk
{
    private GetInputManager _getInput;
    // Rigidbody2DÇÃéQè∆
    private Rigidbody2D _playerRigidbody = null;



    void Start()
    {
        // Rigidbody2DÇéÊìæ
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _getInput = GetInputManager.Instance;
    }

    private void Update()
    {
        UpdateMove();
    }

    public void UpdateMove()
    {
        if (_getInput.IsRightMove)
        {
            RightWalk();
        }
        else if (_getInput.IsLeftMove)
        {
            LeftWalk();
        }
    }
    public void RightWalk()
    {
        _playerRigidbody.velocity = new Vector2(WalkSpeed, _playerRigidbody.velocity.y);
    }

    public void LeftWalk()
    {
        _playerRigidbody.velocity = new Vector2(-WalkSpeed, _playerRigidbody.velocity.y);
    }
}
