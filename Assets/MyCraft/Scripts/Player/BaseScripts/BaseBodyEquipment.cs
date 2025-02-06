using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBodyEquipment : MonoBehaviour
{
    protected Rigidbody2D _playerRigidbody = default;
    protected BoxCollider2D _playerCupsuleCollider = default;
    protected BodyEquipmentData _equipmentData;
    protected GameObject _player;
    protected float JumpPower =>_equipmentData.JumpPower ;
    protected float WalkSpeed  =>_equipmentData.MoveSpeed;
    public int Deffence => _equipmentData.Defense;
    
    protected bool IsJump { get; set; } = false;

    protected void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerRigidbody = _player.GetComponent<Rigidbody2D>();
        _playerCupsuleCollider = _player.GetComponent<BoxCollider2D>();

        _equipmentData = _player.GetComponent<Player>().GetBodyEquipmentData();
        // プレイヤーの衝突検知スクリプトを取得
        CollisionDetector collisionDetector = _player.GetComponent<CollisionDetector>();
        if (collisionDetector != null)
        {
            collisionDetector.OnPlayerCollisionStay += HandleCollisionStay;
            collisionDetector.OnPlayerCollisionExit += HandleCollisionExit;
        }     
    }

   
    public abstract void RightWalk();
    public abstract void LeftWalk();

    public abstract void Jump();
    //protected abstract void HandleCollisionStay(Collision2D collision);
    public void StopMove()
    {
        _playerRigidbody.velocity = new Vector2(0, 0);
    }public void GetKeyUpStopMove()
    {
        _playerRigidbody.velocity = new Vector2(0, _playerRigidbody.velocity.y);
        
    }
    protected abstract void HandleCollisionStay(Collision2D collision);
    protected abstract void HandleCollisionExit(Collision2D collider2D);
}
