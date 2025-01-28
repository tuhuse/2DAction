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
    /// �g�̑�����ύX���鏈��
    /// </summary>
    /// <param name="index">�������镐��̃C���x���g�����̃C���f�b�N�X</param>
    public void EquipBodyEquipment(int index)
    {
        // �C���x���g������V�����������擾
        BodyEquipmentData newEquipment = _inventorySystem.GetBodyEquipment(index);

        if (newEquipment != null)
        {
            // ���݂̑������C���x���g���ɖ߂�
            BodyEquipmentData currentEquipment = _playerEquipment.BodyEquipmentData;
            if (currentEquipment != null)
            {
                _inventorySystem.AddBodyEquipment(currentEquipment);
            }

            // �V���������ɕύX
            _playerEquipment.ChangeBodyEquiment(newEquipment);
        }
    }

    /// <summary>
    /// ���푕����ύX���鏈��
    /// </summary>
    /// <param name="index">�������镐��̃C���x���g�����̃C���f�b�N�X</param>
    public void EquipWeapon(int index)
    {
        // �C���x���g������V����������擾
        WeaponEqupmentData newWeapon = _inventorySystem.GetWeaponEquipment(index);

        if (newWeapon != null)
        {
            // ���݂̕�����C���x���g���ɖ߂�
            WeaponEqupmentData currentWeapon = _playerEquipment.WeaponEquipmentData;
            if (currentWeapon != null)
            {
                _inventorySystem.AddWeaponEquipment(currentWeapon);
            }

            // �V��������ɕύX
            _playerEquipment.ChangeWeaponEquiment(newWeapon);
        }
    }
}
