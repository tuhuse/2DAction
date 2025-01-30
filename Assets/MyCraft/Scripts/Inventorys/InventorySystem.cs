using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// インベントリ追加・取得
/// </summary>
public class InventorySystem : MonoBehaviour
{
    private List<BodyEquipmentData> _bodyEquipment = new List<BodyEquipmentData>();
    private List<WeaponEquipmentData> _weaponEquipment = new List<WeaponEquipmentData>();
    private InventoryUI _inventoryUI;

    private int maxBodyEquipmentSlots = 10;
    private int maxWeaponEquipmentSlots = 5;
    private void Awake()
    {
        _inventoryUI = GetComponent<InventoryUI>();
    }
    /// <summary>
    /// 装備をインベントリに追加する
    /// </summary>
    /// <param name="equipment">装備データ</param>
    public void AddBodyEquipment(BodyEquipmentData equipment)
    {
        if (_bodyEquipment.Count >= maxBodyEquipmentSlots)
        {
            Debug.Log("入りきらない");
            return;
        }
        if (!_bodyEquipment.Contains(equipment))
        {
            _bodyEquipment.Add(equipment);

            // 追加されたインデックスを取得
            int index = _bodyEquipment.Count - 1;

            // UIを更新
            _inventoryUI.UpdateEquipmentInventoryUI(equipment, index);
        }
    }
    /// <summary>
    /// 武器をインベントリに追加する
    /// </summary>
    /// <param name="equipment">武器データ</param>
    public void AddWeaponEquipment(WeaponEquipmentData equipment)
    {
        if (_weaponEquipment.Count >= maxWeaponEquipmentSlots)
        {
            Debug.Log("入りきらない");
            return;
        }
        if (!_weaponEquipment.Contains(equipment))
        {
            _weaponEquipment.Add(equipment);

            // 追加されたインデックスを取得
            int index = _weaponEquipment.Count - 1;

            // UIを更新
            _inventoryUI.UpdateWeaponInventoryUI(equipment, index);
        }
    }

    /// <summary>
    /// インベントリに入っている装備を取得する
    /// </summary>
    /// <param name="index">装備インベントリ番号</param>
    /// <returns></returns>
    public BodyEquipmentData GetBodyEquipment(int index)
    {
        if (index >= 0 && index < _bodyEquipment.Count)
        {
            return _bodyEquipment[index];
        }

        Debug.Log("nanimohaittenai");
        return null;
    }
    /// <summary>
    /// インベントリに入っている武器を取得する
    /// </summary>
    /// <param name="index">武器インベントリ番号</param>
    /// <returns></returns>
    public WeaponEquipmentData GetWeaponEquipment(int index)
    {
        if (index >= 0 && index < _weaponEquipment.Count)
        {
            return _weaponEquipment[index];
        }

        Debug.Log("nanimohaittenai");
        return null;
    }
}
