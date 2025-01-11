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
        _weapon = GetComponent<SordWeapon>();
        _distanceEnemy = GetComponent<BaseDistanceEnemy>();
        // コンポーネントが存在しない場合の警告
        if (_baseBodyEquipment== null) Debug.LogWarning("BasePlayerWalk component is missing!");
        if (_weapon == null) Debug.LogWarning("BasePlayerAttack component is missing!");
    }
  
    public void RightWalk()
    {
        if (_baseBodyEquipment != null)
        {
            _baseBodyEquipment.RightWalk();
        }
        else
        {
            _equipmentInventory.NullEquipment();
        }
    }

    public void LeftWalk()
    {
        if (_baseBodyEquipment != null)
        {
            _baseBodyEquipment.LeftWalk();
        }
        else
        {
            _equipmentInventory.NullEquipment();
        }
    }

    public void Jump()
    {
        if (_baseBodyEquipment != null)
        {
            _baseBodyEquipment.Jump();
        }
        else
        {
            _equipmentInventory.NullEquipment();
        }
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
}
