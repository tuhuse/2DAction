using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private List<BodyEquipmentData> _bodyEquipments = new List<BodyEquipmentData>();
    private List<WeaponEqupmentData> _weaponEquipments = new List<WeaponEqupmentData>();

    public void AddBodyEquipment(BodyEquipmentData equipment)
    {
        if (!_bodyEquipments.Contains(equipment))
        {
            _bodyEquipments.Add(equipment);
            Debug.Log($"Added Body Equipment: {equipment.name}");
        }
    }

    public void AddWeaponEquipment(WeaponEqupmentData equipment)
    {
        if (!_weaponEquipments.Contains(equipment))
        {
            _weaponEquipments.Add(equipment);
            Debug.Log($"Added Weapon Equipment: {equipment.name}");
        }
    }

    public BodyEquipmentData GetBodyEquipment(int index)
    {
        if (index >= 0 && index < _bodyEquipments.Count)
        {
            return _bodyEquipments[index];
        }

        Debug.LogError("Invalid body equipment index.");
        return null;
    }

    public WeaponEqupmentData GetWeaponEquipment(int index)
    {
        if (index >= 0 && index < _weaponEquipments.Count)
        {
            return _weaponEquipments[index];
        }

        Debug.LogError("Invalid weapon equipment index.");
        return null;
    }
}
