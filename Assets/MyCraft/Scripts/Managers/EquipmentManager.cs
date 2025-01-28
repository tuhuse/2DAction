using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField] private InventorySystem _inventorySystem;
    [SerializeField] private EquipmentInventory _equipmentInventory;


    /// <summary>
    /// �g�̑�����ύX���鏈��
    /// </summary>
    /// <param name="index"></param>
    public void EquipBodyEquipment(int index)
    {
        // �C���x���g������V�����������擾
        BodyEquipmentData newEquipment = _inventorySystem.GetBodyEquipment(index);

        if (newEquipment != null)
        {
            // ���݂̑������C���x���g���ɖ߂�
            BodyEquipmentData currentEquipment = _equipmentInventory.BodyEquipmentData;
            if (currentEquipment != null)
            {
                _inventorySystem.AddBodyEquipment(currentEquipment);
            }

            // �V���������ɕύX
            _equipmentInventory.ChangeBodyEquiment(newEquipment);
        }
    }

    /// <summary>
    /// ���푕����ύX���鏈��
    /// </summary>
    /// <param name="index"></param>
    public void EquipWeapon(int index)
    {
        // �C���x���g������V����������擾
        WeaponEqupmentData newWeapon = _inventorySystem.GetWeaponEquipment(index);

        if (newWeapon != null)
        {
            // ���݂̕�����C���x���g���ɖ߂�
            WeaponEqupmentData currentWeapon = _equipmentInventory.WeaponEquipmentData;
            if (currentWeapon != null)
            {
                _inventorySystem.AddWeaponEquipment(currentWeapon);
            }

            // �V��������ɕύX
            _equipmentInventory.ChangeWeaponEquiment(newWeapon);
        }
    }
}
