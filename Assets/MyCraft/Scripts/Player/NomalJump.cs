using UnityEngine;
/// <summary>
/// �W�����v������
/// </summary>
public class NomalJump : BasePlayerJump
{
    private GetInputManager _getInput;
    private Rigidbody2D _playerRigidbody = default;
    private BoxCollider2D _playerBoxCollider= default;
    private const int MAX_JUMP_COUNT = 2;
    private int _currentJumpCount = 0;
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _playerBoxCollider = GetComponent<BoxCollider2D>();
        _getInput = GetInputManager.Instance;
    }
    private void Update()
    {
        if (_getInput.CanJump&&!IsJump)
        {
            Jump();
        }
       
    }
    
    /// <summary>
    /// �ʏ푕���̃W�����v
    /// </summary>
    public override void Jump()
    {
        if (_currentJumpCount < MAX_JUMP_COUNT)
        {
            _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, JumpPower);
            _currentJumpCount++;
            IsJump = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            IsJump = false;
            _currentJumpCount = 0;
        }
    }
  
}
