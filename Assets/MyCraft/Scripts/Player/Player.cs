using UnityEngine;

/// <summary>
/// プレイヤーの動作を処理する
/// </summary>

public class Player : MonoBehaviour
{
  
   
    private BaseAttackRange _distanceEnemy;
    private PlayerEquipmentManager _equipmentManager;

    public BaseAttackRange DistanceEnemy => _distanceEnemy;
    private BaseWeapon _weapon => _equipmentManager.EquipWeapon;
    private BaseBodyEquipment BaseBodyEquipment => _equipmentManager.BaseBodyEquipment;
    private void Awake()
    {

        _equipmentManager = GameObject.FindFirstObjectByType<PlayerEquipmentManager>();
        // 動的にコンポーネントを解決
    }
    private void Start()
    {

        if (!TryGetComponent(out _distanceEnemy))
        {
            Debug.LogWarning("DistanceEnemy component is missing!");
            _distanceEnemy = gameObject.AddComponent<SordAttackRange>();
        }
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
        if (_distanceEnemy.CanAttack)
        {
            if (_weapon != null)
            {
                _weapon.TryAttack();
            }
            else
            {
                _equipmentManager.InitializeWeapon();
            }
            
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
