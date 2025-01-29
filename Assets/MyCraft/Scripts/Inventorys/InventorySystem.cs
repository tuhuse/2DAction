using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private List<BodyEquipmentData> _bodyEquipments = new List<BodyEquipmentData>();
    private List<WeaponEquipmentData> _weaponEquipments = new List<WeaponEquipmentData>();
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
        _inventoryUI = GameObject.FindFirstObjectByType<InventoryUI>();
    }
    public void AddBodyEquipment(BodyEquipmentData equipment)
    {
        if (!_bodyEquipments.Contains(equipment))
        {
            _bodyEquipments.Add(equipment);

            // �ǉ����ꂽ�C���f�b�N�X���擾
            int index = _bodyEquipments.Count - 1;

            // UI���X�V
            _inventoryUI.UpdateEquipmentInventoryUI(equipment, index);
        }
    }

    public void AddWeaponEquipment(WeaponEquipmentData equipment)
    {
        if (!_weaponEquipments.Contains(equipment))
        {
            _weaponEquipments.Add(equipment);

            // �ǉ����ꂽ�C���f�b�N�X���擾
            int index = _weaponEquipments.Count - 1;

            // UI���X�V
            _inventoryUI.UpdateWeaponInventoryUI(equipment, index);
        }
    }


    public BodyEquipmentData GetBodyEquipment(int index)
    {
        if (index >= 0 && index < _bodyEquipments.Count)
        {
            return _bodyEquipments[index];
        }

        Debug.Log("nanimohaittenai");
        return null;
    }

    public WeaponEquipmentData GetWeaponEquipment(int index)
    {
        if (index >= 0 && index < _weaponEquipments.Count)
        {
            return _weaponEquipments[index];
        }

        Debug.Log("nanimohaittenai");
        return null;
    }
}
