using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public abstract class BaseWeapon : MonoBehaviour
{
    protected WeaponEquipmentData _weaponData=default;
   protected GameObject _weapon = default;
  
    protected bool _isAttackCoolDown = false;
    protected GameObject _player;
    protected float _attackCoolDown => _weaponData.AttackInterval;
    public int AttackPower => _weaponData.AttackPower;
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
       
        _weaponData = _player.GetComponent<Player>().GetWeaponData();
    }
    public void TryAttack()
    {
        if (!_isAttackCoolDown)
        {
            Attack();
        }
    }
    public abstract void Attack();
   
}
