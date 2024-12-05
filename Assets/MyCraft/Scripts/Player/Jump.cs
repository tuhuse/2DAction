using UnityEngine;

public class Jump : MonoBehaviour,IJump
{
    private Rigidbody2D _playerRigidbody = default;
    public float JumpPower { get; set; } = 5f;
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

   

    void IJump.Jump()
    {
        _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, JumpPower);
    }
}
