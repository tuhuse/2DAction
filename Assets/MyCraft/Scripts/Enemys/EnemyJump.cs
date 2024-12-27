using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour
{
    private const float JUMP_FORCE = 5.0f;
    private Rigidbody2D _rb2D;
    public float JumpForce { get; set; } = JUMP_FORCE;
    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    public void PerformJump()
    {
        if (_rb2D != null)
        {
            _rb2D.AddForce(Vector3.up * JumpForce, ForceMode2D.Impulse);
        }
    }
}
