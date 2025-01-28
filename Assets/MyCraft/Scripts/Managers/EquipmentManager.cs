using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField] private InventorySystem _inventorySystem;
    [SerializeField] private EquipmentInventory _equipmentInventory;


    /// <summary>
    /// 身体装備を変更する処理
    /// </summary>
    /// <param name="index"></param>
    public void EquipBodyEquipment(int index)
    {
        // インベントリから新しい装備を取得
        BodyEquipmentData newEquipment = _inventorySystem.GetBodyEquipment(index);

        if (newEquipment != null)
        {
            // 現在の装備をインベントリに戻す
            BodyEquipmentData currentEquipment = _equipmentInventory.BodyEquipmentData;
            if (currentEquipment != null)
            {
                _inventorySystem.AddBodyEquipment(currentEquipment);
            }

            // 新しい装備に変更
            _equipmentInventory.ChangeBodyEquiment(newEquipment);
        }
    }

    /// <summary>
    /// 武器装備を変更する処理
    /// </summary>
    /// <param name="index"></param>
    public void EquipWeapon(int index)
    {
        // インベントリから新しい武器を取得
        WeaponEqupmentData newWeapon = _inventorySystem.GetWeaponEquipment(index);

        if (newWeapon != null)
        {
            // 現在の武器をインベントリに戻す
            WeaponEqupmentData currentWeapon = _equipmentInventory.WeaponEquipmentData;
            if (currentWeapon != null)
            {
                _inventorySystem.AddWeaponEquipment(currentWeapon);
            }

            // 新しい武器に変更
            _equipmentInventory.ChangeWeaponEquiment(newWeapon);
        }
    }
}
