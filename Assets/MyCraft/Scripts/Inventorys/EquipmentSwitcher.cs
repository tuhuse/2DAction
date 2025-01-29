using UnityEngine;

public class EquipmentSwitcher : MonoBehaviour
{
     private InventorySystem _inventorySystem;
     private PlayerEquipmentManager _playerEquipment;


    private void Start()
    {
        _inventorySystem=InventorySystem.Instance;
        _playerEquipment = PlayerEquipmentManager.Instance;
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
            BodyEquipmentData currentEquipment = _playerEquipment.NowBodyEquipment;
            if (currentEquipment != null)
            {
                _inventorySystem.AddBodyEquipment(currentEquipment);
            }

            // �V���������ɕύX
            _playerEquipment.ChangeBodyEquipment(newEquipment);
        }
    }

    /// <summary>
    /// ���푕����ύX���鏈��
    /// </summary>
    /// <param name="index">�������镐��̃C���x���g�����̃C���f�b�N�X</param>
    public void EquipWeapon(int index)
    {
        // �C���x���g������V����������擾
        WeaponEquipmentData newWeapon = _inventorySystem.GetWeaponEquipment(index);

        if (newWeapon != null)
        {
            // ���݂̕�����C���x���g���ɖ߂�
            WeaponEquipmentData currentWeapon = _playerEquipment.NowWeapon;
            if (currentWeapon != null)
            {
                _inventorySystem.AddWeaponEquipment(currentWeapon);
            }

            // �V��������ɕύX
            _playerEquipment.ChangeWeaponEquipment(newWeapon);
        }
    }
}
