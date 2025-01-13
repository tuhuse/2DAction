using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBodyEquipment : MonoBehaviour
{
    protected Rigidbody2D _playerRigidbody = default;
    protected BoxCollider2D _playerBoxCollider = default;
    protected BodyEquipmentData _equeipmentdata;
    protected GameObject _player;
    protected float JumpPower =>_equeipmentdata.JumpPower ;
    protected float WalkSpeed  =>_equeipmentdata.MoveSpeed;
    public int Deffence => _equeipmentdata.Defense;
    protected bool IsJump { get; set; } = false;

    protected abstract void Start();   
    public abstract void RightWalk();
    public abstract void LeftWalk();

    public abstract void Jump();
    //protected abstract void HandleCollisionStay(Collision2D collision);
    public void SetEqueipment()
    {
        _equeipmentdata = EquipmentInventory.Instance.BodyEquipmentData;
    }
    
}
