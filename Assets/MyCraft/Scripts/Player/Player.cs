using UnityEngine;

/// <summary>
/// プレイヤーの動作を処理する
/// </summary>

public class Player : MonoBehaviour
{
  
    private BaseWeapon _weapon;
    private BaseDistanceEnemy _distanceEnemy;
    private PlayerEquipmentManager _equipmentManager;

    public BaseDistanceEnemy DistanceEnemy => _distanceEnemy;
    private BaseBodyEquipment BaseBodyEquipment => _equipmentManager.BaseBodyEquipment;
  
    private void Start()
    {
        _equipmentManager = GameObject.FindFirstObjectByType<PlayerEquipmentManager>();
        // 動的にコンポーネントを解決
        if (!TryGetComponent(out _weapon))
        {
            Debug.LogWarning("Weapon component is missing! Adding default.");
            _weapon = gameObject.AddComponent<SordWeapon>();
        }

        if (!TryGetComponent(out _distanceEnemy))
        {
            Debug.LogWarning("DistanceEnemy component is missing!");
            _distanceEnemy = gameObject.AddComponent<SordDistanceEnemy>();
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
                _weapon = gameObject.AddComponent<SordWeapon>();
            }
            
        }
        
    }
    private void EnsureEquipmentInitialized()
    {
        if (BaseBodyEquipment == null)
        {
            _equipmentManager.InitializeEquipment();
            Debug.LogWarning("BaseBodyEquipment initialized dynamically.");
        }
    }
    public BodyEquipmentData GetBodyEquipmentData()
    {
        return _equipmentManager.CurrentBodyEquipment;
    }
}
