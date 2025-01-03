using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForrowSoldierEnemyMove : BaseEnemyMove
{
    protected Rigidbody2D _rb2d;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }
    public override void EnemyMove()
    {
        if (IsRightSwitch)
        {
            _rb2d.velocity = new Vector2(MoveSpeed, _rb2d.velocity.y);
        }
        else
        {
            _rb2d.velocity = new Vector2(-MoveSpeed, _rb2d.velocity.y);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Edge"))
        {
            if (IsRightSwitch)
            {
                IsRightSwitch = false;
            }
            else
            {
                IsRightSwitch = true;
            }
        }
    }
}
