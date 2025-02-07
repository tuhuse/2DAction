using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// インベントリの管理を行うシステム
/// 装備や武器の追加・削除・取得の機能をもっている
/// </summary>
public class InventorySystem : MonoBehaviour
{
    private List<BodyEquipmentData> _bodyEquipment = new List<BodyEquipmentData>();
    private List<WeaponEquipmentData> _weaponEquipment = new List<WeaponEquipmentData>();
    private InventoryUI _inventoryUI=default;

    private int _maxBodyEquipmentSlots = 5;
    private int _maxWeaponEquipmentSlots = 3;
    private void Start()
    {
        _inventoryUI = GetComponent<InventoryUI>();
    }
    /// <summary>
    /// 装備をインベントリに追加する
    /// </summary>
    /// <param name="equipment">装備データ</param>
    public void AddBodyEquipment(BodyEquipmentData equipment)
    {
        if (_bodyEquipment.Count >= _maxBodyEquipmentSlots)
        {
            return;
        }
        if (!_bodyEquipment.Contains(equipment))
        {
            _bodyEquipment.Add(equipment);

            // 追加されたインデックスを取得
            int index = _bodyEquipment.Count - 1;

            // UIを更新
            _inventoryUI.UpdateAddEquipmentInventoryUI(equipment, index);
        }
    }
   
    /// <summary>
    /// 武器をインベントリに追加する
    /// </summary>
    /// <param name="equipment">武器データ</param>
    public void AddWeaponEquipment(WeaponEquipmentData equipment)
    {
        if (_weaponEquipment.Count >= _maxWeaponEquipmentSlots)
        {
            return;
        }
        if (!_weaponEquipment.Contains(equipment))
        {
            _weaponEquipment.Add(equipment);

            // 追加されたインデックスを取得
            int index = _weaponEquipment.Count - 1;

            // UIを更新
            _inventoryUI.UpdateAddWeaponInventoryUI(equipment, index);
        }
    }
    /// <summary>
      /// 装備をインベントリから削除する
      /// </summary>
      /// <param name="equipment">武器データ</param>
    public void RemoveBodyEquipment(BodyEquipmentData equipment)
    {

        if (_bodyEquipment.Contains(equipment))
        {
            _bodyEquipment.Remove(equipment);
            // 追加されたインデックスを取得
            int index = _bodyEquipment.Count - 1;
            //_inventoryUI.UpdateRemoveEquipmentInventoryUI(equipment, index);
        }
    }
    /// <summary>
    /// 武器をインベントリから削除する
    /// </summary>
    /// <param name="equipment">武器データ</param>
    public void RemoveWeaponEquipment(WeaponEquipmentData equipment)
    {

        if (_weaponEquipment.Contains(equipment))
        {
            _weaponEquipment.Remove(equipment);
            // 追加されたインデックスを取得
            int index = _weaponEquipment.Count - 1;
            //_inventoryUI.UpdateRemoveWeaponInventoryUI(equipment, index);
        }
    }
    /// <summary>
    /// 指定したインベントリスロットに装備データを追加する。
    /// </summary>
    /// <param name="equipment">装備データ</param>
    /// <param name="index">インベントリ番号</param>
    public void AddBodyEquipmentAt(BodyEquipmentData equipment, int index)
    {
        if (index < 0 || index > _bodyEquipment.Count)
        {
            return;
        }

        _bodyEquipment.Insert(index, equipment);

        // UIを更新
        _inventoryUI.UpdateAddEquipmentInventoryUI(equipment, index);
    }

    /// <summary>
    /// 指定したインベントリスロットに入っている装備データを取得する
    /// </summary>
    /// <param name="index">装備インベントリ番号</param>
    /// <returns>装備データ</returns>
    public BodyEquipmentData GetBodyEquipment(int index)
    {
        if (index >= 0 && index < _bodyEquipment.Count)
        {
            return _bodyEquipment[index];
        }
        return null;
    }
    /// <summary>
    /// 指定したインベントリスロットに入っている武器データを取得する
    /// </summary>
    /// <param name="index">武器インベントリ番号</param>
    /// <returns>武器のデータ</returns>
    public WeaponEquipmentData GetWeaponEquipment(int index)
    {
        if (index >= 0 && index < _weaponEquipment.Count)
        {
            return _weaponEquipment[index];
        }
        return null;
    }
}
