using UnityEngine;

public class PlayerWalk : BasePlayerWalk
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
        if (_getInput.CanRightMove)
        {
            RightWalK();
        }
        else if (_getInput.CanLeftMove)
        {
            LeftWalK();
        }
    }
    public override void RightWalK()
    {
        _playerRigidbody.velocity = new Vector2(WalkSpeed, _playerRigidbody.velocity.y);
    }

    public override void LeftWalK()
    {
        _playerRigidbody.velocity = new Vector2(-WalkSpeed, _playerRigidbody.velocity.y);
    }
}
