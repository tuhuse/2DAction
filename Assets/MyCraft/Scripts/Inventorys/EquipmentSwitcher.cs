using UnityEngine;
/// <summary>
/// インベントリから装備をする処理
/// </summary>
public class EquipmentSwitcher : MonoBehaviour
{
    private InventorySystem _inventorySystem;
    private PlayerEquipmentManager _playerEquipment;


    private void Start()
    {
        _inventorySystem = GetComponent<InventorySystem>();
        _playerEquipment = GetComponent<PlayerEquipmentManager>();
    }
    /// <summary>
    /// 装備を変更する処理
    /// </summary>
    /// <param name="index">装備する武器のインベントリ内のインデックス</param>
    public void EquipBodyEquipment(int index)
    {
        if (_inventorySystem == null || _playerEquipment == null)
        {
            Debug.Log("ない");
            return;
        }
        // インベントリから新しい装備を取得
        BodyEquipmentData newEquipment = _inventorySystem.GetBodyEquipment(index);
       
        if (newEquipment == null)
        {
            return;
        }
        _inventorySystem.RemoveBodyEquipment(_inventorySystem.GetBodyEquipment(index));
        // 現在の装備をインベントリに戻す
        BodyEquipmentData currentEquipment = _playerEquipment.CurrentBodyEquipment;
        if (currentEquipment != null)
        {
            _inventorySystem.AddBodyEquipment(currentEquipment);
        }

        // 新しい装備に変更
        _playerEquipment.ChangeBodyEquipment(newEquipment);

    }

    /// <summary>
    /// 武器装備を変更する処理
    /// </summary>
    /// <param name="index">装備する武器のインベントリ内のインデックス</param>
    public void EquipWeapon(int index)
    {
        // インベントリから新しい武器を取得
        WeaponEquipmentData newWeapon = _inventorySystem.GetWeaponEquipment(index);
        
        if (newWeapon == null)
        {
            return; 
        }
        _inventorySystem.RemoveWeaponEquipment(_inventorySystem.GetWeaponEquipment(index));
        // 現在の武器をインベントリに戻す
        WeaponEquipmentData currentWeapon = _playerEquipment.CurrentWeaponEquipment;

        if (currentWeapon != null)
        {
            _inventorySystem.AddWeaponEquipment(currentWeapon);
        }

        // 新しい武器に変更
        _playerEquipment.ChangeWeaponEquipment(newWeapon);
    }
}
