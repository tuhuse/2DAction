using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField] private InventorySystem _inventorySystem;
    [SerializeField] private EquipmentInventory _equipmentInventory;

    public void EquipBodyEquipment(int index)
    {
        BodyEquipmentData equipment = _inventorySystem.GetBodyEquipment(index);
        if (equipment != null)
        {
            _equipmentInventory.ChangeBodyEquiment(equipment);
            Debug.Log($"Equipped Body Equipment: {equipment.name}");
        }
    }

    public void EquipWeapon(int index)
    {
        WeaponEqupmentData weapon = _inventorySystem.GetWeaponEquipment(index);
        if (weapon != null)
        {
            // ‚±‚±‚Å•Ší‘•”õ‚Ìˆ—‚ğŒÄ‚Ño‚·
            Debug.Log($"Equipped Weapon: {weapon.name}");
        }
    }
}
