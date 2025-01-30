using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �C���x���g���ǉ��E�擾
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
    /// �������C���x���g���ɒǉ�����
    /// </summary>
    /// <param name="equipment">�����f�[�^</param>
    public void AddBodyEquipment(BodyEquipmentData equipment)
    {
        if (_bodyEquipment.Count >= maxBodyEquipmentSlots)
        {
            Debug.Log("���肫��Ȃ�");
            return;
        }
        if (!_bodyEquipment.Contains(equipment))
        {
            _bodyEquipment.Add(equipment);

            // �ǉ����ꂽ�C���f�b�N�X���擾
            int index = _bodyEquipment.Count - 1;

            // UI���X�V
            _inventoryUI.UpdateEquipmentInventoryUI(equipment, index);
        }
    }
    /// <summary>
    /// ������C���x���g���ɒǉ�����
    /// </summary>
    /// <param name="equipment">����f�[�^</param>
    public void AddWeaponEquipment(WeaponEquipmentData equipment)
    {
        if (_weaponEquipment.Count >= maxWeaponEquipmentSlots)
        {
            Debug.Log("���肫��Ȃ�");
            return;
        }
        if (!_weaponEquipment.Contains(equipment))
        {
            _weaponEquipment.Add(equipment);

            // �ǉ����ꂽ�C���f�b�N�X���擾
            int index = _weaponEquipment.Count - 1;

            // UI���X�V
            _inventoryUI.UpdateWeaponInventoryUI(equipment, index);
        }
    }

    /// <summary>
    /// �C���x���g���ɓ����Ă��鑕�����擾����
    /// </summary>
    /// <param name="index">�����C���x���g���ԍ�</param>
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
    /// �C���x���g���ɓ����Ă��镐����擾����
    /// </summary>
    /// <param name="index">����C���x���g���ԍ�</param>
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
