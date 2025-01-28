using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private List<BodyEquipmentData> _bodyEquipments = new List<BodyEquipmentData>();
    private List<WeaponEqupmentData> _weaponEquipments = new List<WeaponEqupmentData>();
    private InventoryUI _inventoryUI;

    public static InventorySystem Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    private void Start()
    {
        _inventoryUI = GameObject.FindAnyObjectByType<InventoryUI>();
    }
    public void AddBodyEquipment(BodyEquipmentData equipment)
    {
        if (!_bodyEquipments.Contains(equipment))
        {
            _bodyEquipments.Add(equipment);

            // 追加されたインデックスを取得
            int index = _bodyEquipments.Count - 1;

            // UIを更新
            _inventoryUI.UpdateEquipmentInventoryUI(equipment, index);
        }
    }

    public void AddWeaponEquipment(WeaponEqupmentData equipment)
    {
        if (!_weaponEquipments.Contains(equipment))
        {
            _weaponEquipments.Add(equipment);

            // 追加されたインデックスを取得
            int index = _weaponEquipments.Count - 1;

            // UIを更新
            _inventoryUI.UpdateWeaponInventoryUI(equipment, index);
        }
    }


    public BodyEquipmentData GetBodyEquipment(int index)
    {
        if (index >= 0 && index < _bodyEquipments.Count)
        {
            return _bodyEquipments[index];
        }

        Debug.LogError("nanimohaittenai");
        return null;
    }

    public WeaponEqupmentData GetWeaponEquipment(int index)
    {
        if (index >= 0 && index < _weaponEquipments.Count)
        {
            return _weaponEquipments[index];
        }

        Debug.LogError("nanimohaittenai");
        return null;
    }
}
