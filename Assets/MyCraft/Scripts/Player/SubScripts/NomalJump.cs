using UnityEngine;
/// <summary>
/// ジャンプをする
/// </summary>
public class NomalJump : BasePlayerJump
{
    
    private Rigidbody2D _playerRigidbody = default;
    private BoxCollider2D _playerBoxCollider= default;
    private const int MAX_JUMP_COUNT = 2;
    private int _currentJumpCount = 0;
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _playerBoxCollider = GetComponent<BoxCollider2D>();
      
    }
   
    
    /// <summary>
    /// 通常装備のジャンプ
    /// </summary>
    public override void Jump()
    {
        if (!IsJump)
        {
            if (_currentJumpCount < MAX_JUMP_COUNT)
            {
                _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, JumpPower);
                _currentJumpCount++;
                IsJump = true;
            }
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
