using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSoldierEnemyMove : BaseEnemyMove
{
    protected Rigidbody2D _rb2d;
    private bool _isEdge = false;
    private const int WAIT_TIME = 3;
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
    publicÅ@override void FollowLeftMove()
    {
        if (!_isEdge)
        {
            _rb2d.velocity = new Vector2(-MoveSpeed, _rb2d.velocity.y);
        }
        else
        {
            _rb2d.velocity = new Vector2(MoveSpeed, _rb2d.velocity.y);
        }
        
    }public override void FllowRightMove()
    {
        if (!_isEdge)
        {
            _rb2d.velocity = new Vector2(MoveSpeed, _rb2d.velocity.y);
        }
        else
        {
            _rb2d.velocity = new Vector2(-MoveSpeed, _rb2d.velocity.y);
        }
           
    }
    private IEnumerator EdgeCoolDown()
    {
        _isEdge = true;
        yield return new WaitForSeconds(WAIT_TIME);
        _isEdge = false;
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
            StartCoroutine(EdgeCoolDown());
        }
    }
}
