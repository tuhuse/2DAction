using UnityEngine;


public class Player : MonoBehaviour
{
  
    private BaseWeapon _weapon;
    private BaseDistanceEnemy _distanceEnemy;
    private EquipmentInventory _equipmentInventory;
    private BaseBodyEquipment _baseBodyEquipment => _equipmentInventory.BaseBodyEquipment;
  
    private void Start()
    {
        _equipmentInventory = EquipmentInventory.Instance;

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
        if (_baseBodyEquipment != null)
        {
            if (!_equipmentInventory.IsChangeEquipment)
            {
                _baseBodyEquipment.RightWalk();
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                _baseBodyEquipment.StopMove();
            }
        }
    }


    public void LeftWalk()
    {
        EnsureEquipmentInitialized();
        if (_baseBodyEquipment != null)
        {
           
            if (!_equipmentInventory.IsChangeEquipment)
            {
                _baseBodyEquipment.LeftWalk();
                this.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                _baseBodyEquipment.StopMove();
            }
        }
     
    }

    public void Jump()
    {
        EnsureEquipmentInitialized();
        if (_baseBodyEquipment != null)
        {
            _baseBodyEquipment.Jump();
        }
     
    }
    public void MoveStop()
    {
        _baseBodyEquipment.GetKeyUpStopMove();
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
        if (_baseBodyEquipment == null)
        {
            _equipmentInventory.InitializeEquipment();
            Debug.LogWarning("BaseBodyEquipment initialized dynamically.");
        }
    }

}
