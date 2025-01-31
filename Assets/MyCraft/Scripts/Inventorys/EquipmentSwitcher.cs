using UnityEngine;
/// <summary>
/// �C���x���g�����瑕�������鏈��
/// </summary>
public class EquipmentSwitcher : MonoBehaviour
{
    private InventorySystem _inventorySystem;
    private PlayerEquipmentManager _playerEquipment;


    private void Start()
    {
        _inventorySystem = GetComponent<InventorySystem>();
        _playerEquipment = GetComponent<PlayerEquipmentManager>();
    }
    /// <summary>
    /// ������ύX���鏈��
    /// </summary>
    /// <param name="index">�������镐��̃C���x���g�����̃C���f�b�N�X</param>
    public void EquipBodyEquipment(int index)
    {
        if (_inventorySystem == null || _playerEquipment == null)
        {
            Debug.Log("�Ȃ�");
            return;
        }
        // �C���x���g������V�����������擾
        BodyEquipmentData newEquipment = _inventorySystem.GetBodyEquipment(index);
       
        if (newEquipment == null)
        {
            return;
        }
        _inventorySystem.RemoveBodyEquipment(_inventorySystem.GetBodyEquipment(index));
        // ���݂̑������C���x���g���ɖ߂�
        BodyEquipmentData currentEquipment = _playerEquipment.CurrentBodyEquipment;
        if (currentEquipment != null)
        {
            _inventorySystem.AddBodyEquipment(currentEquipment);
        }

        // �V���������ɕύX
        _playerEquipment.ChangeBodyEquipment(newEquipment);

    }

    /// <summary>
    /// ���푕����ύX���鏈��
    /// </summary>
    /// <param name="index">�������镐��̃C���x���g�����̃C���f�b�N�X</param>
    public void EquipWeapon(int index)
    {
        // �C���x���g������V����������擾
        WeaponEquipmentData newWeapon = _inventorySystem.GetWeaponEquipment(index);
        
        if (newWeapon == null)
        {
            return; 
        }
        _inventorySystem.RemoveWeaponEquipment(_inventorySystem.GetWeaponEquipment(index));
        // ���݂̕�����C���x���g���ɖ߂�
        WeaponEquipmentData currentWeapon = _playerEquipment.CurrentWeaponEquipment;

        if (currentWeapon != null)
        {
            _inventorySystem.AddWeaponEquipment(currentWeapon);
        }

        // �V��������ɕύX
        _playerEquipment.ChangeWeaponEquipment(newWeapon);
    }
}
