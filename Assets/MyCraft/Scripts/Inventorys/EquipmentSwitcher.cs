using UnityEngine;
/// <summary>
/// インベントリ内の装備をプレイヤーに適用するクラス
/// 装備を変更すると、現在の装備がインベントリに戻り、新しい装備プレイヤーに適用させる
/// </summary>
public class EquipmentSwitcher : MonoBehaviour
{
    private InventorySystem _inventorySystem=default;
    private PlayerEquipmentManager _playerEquipment=default;

    private void Start()
    {
        _inventorySystem = GetComponent<InventorySystem>();
        _playerEquipment = GetComponent<PlayerEquipmentManager>();
    }

    /// <summary>
    /// 装備を変更する処理
    /// インベントリ内の指定された装備データをプレイヤーに適用し、現在の装備データをインベントリに戻す
    /// </summary>
    /// <param name="index">装備する防具のインベントリ内のインデックス</param>
    public void EquipBodyEquipment(int index)
{
    if (_inventorySystem == null || _playerEquipment == null)
    {
        return;
    }
    // インベントリから新しい装備を取得
    BodyEquipmentData newEquipment = _inventorySystem.GetBodyEquipment(index);
    if (newEquipment == null)
    {
        return;
    }   
    int originalIndex = index;

    // 取得した装備を削除
    _inventorySystem.RemoveBodyEquipment(newEquipment);

    // 現在の装備をインベントリに戻す
    BodyEquipmentData currentEquipment = _playerEquipment.CurrentBodyEquipment;
    if (currentEquipment != null)
    {
        //取得した装備の位置に元の装備を追加する
        _inventorySystem.AddBodyEquipmentAt(currentEquipment, originalIndex);
    }

    // 新しい装備に変更
    _playerEquipment.ChangeBodyEquipment(newEquipment);
}

    /// <summary>
    /// 武器装備を変更する処理
    /// インベントリ内の指定された武器データをプレイヤーに適用し、現在の武器データをインベントリに戻す
    /// </summary>
    /// <param name="index">装備する武器のインベントリ内のインデックス</param>
    public void EquipWeapon(int index)
    {
        if (_inventorySystem == null || _playerEquipment == null)
        {
            return;
        }

        // インベントリから新しい武器を取得
        WeaponEquipmentData newWeapon = _inventorySystem.GetWeaponEquipment(index);
        if (newWeapon == null)
        {
            return;
        }

        // 取得した武器を削除
        _inventorySystem.RemoveWeaponEquipment(newWeapon);

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
