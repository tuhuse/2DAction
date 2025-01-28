using UnityEngine;

public class EquipmentSwitcher : MonoBehaviour
{
     private InventorySystem _inventorySystem;
     private PlayerEquipmentManager _playerEquipment;


    private void Start()
    {
        _inventorySystem=InventorySystem.Instance;
    }
    /// <summary>
    /// 身体装備を変更する処理
    /// </summary>
    /// <param name="index">装備する武器のインベントリ内のインデックス</param>
    public void EquipBodyEquipment(int index)
    {
        // インベントリから新しい装備を取得
        BodyEquipmentData newEquipment = _inventorySystem.GetBodyEquipment(index);

        if (newEquipment != null)
        {
            // 現在の装備をインベントリに戻す
            BodyEquipmentData currentEquipment = _playerEquipment.BodyEquipmentData;
            if (currentEquipment != null)
            {
                _inventorySystem.AddBodyEquipment(currentEquipment);
            }

            // 新しい装備に変更
            _playerEquipment.ChangeBodyEquiment(newEquipment);
        }
    }

    /// <summary>
    /// 武器装備を変更する処理
    /// </summary>
    /// <param name="index">装備する武器のインベントリ内のインデックス</param>
    public void EquipWeapon(int index)
    {
        // インベントリから新しい武器を取得
        WeaponEqupmentData newWeapon = _inventorySystem.GetWeaponEquipment(index);

        if (newWeapon != null)
        {
            // 現在の武器をインベントリに戻す
            WeaponEqupmentData currentWeapon = _playerEquipment.WeaponEquipmentData;
            if (currentWeapon != null)
            {
                _inventorySystem.AddWeaponEquipment(currentWeapon);
            }

            // 新しい武器に変更
            _playerEquipment.ChangeWeaponEquiment(newWeapon);
        }
    }
}
