using UnityEngine;

/// <summary>
/// プレイヤーの動作を処理する
/// </summary>

public class Player : MonoBehaviour
{
  
    private PlayerEquipmentManager _equipmentManager;

    public BaseAttackRange DistanceEnemy =>_equipmentManager.AttackRange;
    public BaseWeapon Weapon => _equipmentManager.EquipWeapon;
    private BaseBodyEquipment BaseBodyEquipment => _equipmentManager.BaseBodyEquipment;
    private void Awake()
    {

        _equipmentManager = GameObject.FindFirstObjectByType<PlayerEquipmentManager>();
        // 動的にコンポーネントを解決
    }
    public void RightWalk()
    {
        EnsureEquipmentInitialized();
        if (BaseBodyEquipment != null)
        {
         
                BaseBodyEquipment.RightWalk();
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }


    public void LeftWalk()
    {
        EnsureEquipmentInitialized();
        if (BaseBodyEquipment != null)
        {        
                BaseBodyEquipment.LeftWalk();
                this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
     
    }

    public void Jump()
    {
        EnsureEquipmentInitialized();
        if (BaseBodyEquipment != null)
        {
            BaseBodyEquipment.Jump();
        }
     
    }
    public void MoveStop()
    {
        BaseBodyEquipment.GetKeyUpStopMove();
    }
    public void Attack()
    {
        if (DistanceEnemy == null|| Weapon == null)
        {
            _equipmentManager.InitializeWeapon();
            return;
        }
        if (DistanceEnemy.CanAttack)
        {         
                Weapon.TryAttack();           
        }
        
    }
    private void EnsureEquipmentInitialized()
    {
        if (BaseBodyEquipment == null)
        {
            _equipmentManager.InitializeEquipment();
          
        }
    }
    public BodyEquipmentData GetBodyEquipmentData()
    {
        return _equipmentManager.CurrentBodyEquipment;
    }
    public WeaponEquipmentData GetWeaponData()
    {
        return _equipmentManager.CurrentWeaponEquipment;
    }
}
