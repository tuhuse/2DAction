using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �C���x���g���̊Ǘ����s���V�X�e��
/// �����═��̒ǉ��E�폜�E�擾�̋@�\�������Ă���
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
    /// �������C���x���g���ɒǉ�����
    /// </summary>
    /// <param name="equipment">�����f�[�^</param>
    public void AddBodyEquipment(BodyEquipmentData equipment)
    {
        if (_bodyEquipment.Count >= _maxBodyEquipmentSlots)
        {
            return;
        }
        if (!_bodyEquipment.Contains(equipment))
        {
            _bodyEquipment.Add(equipment);

            // �ǉ����ꂽ�C���f�b�N�X���擾
            int index = _bodyEquipment.Count - 1;

            // UI���X�V
            _inventoryUI.UpdateAddEquipmentInventoryUI(equipment, index);
        }
    }
   
    /// <summary>
    /// ������C���x���g���ɒǉ�����
    /// </summary>
    /// <param name="equipment">����f�[�^</param>
    public void AddWeaponEquipment(WeaponEquipmentData equipment)
    {
        if (_weaponEquipment.Count >= _maxWeaponEquipmentSlots)
        {
            return;
        }
        if (!_weaponEquipment.Contains(equipment))
        {
            _weaponEquipment.Add(equipment);

            // �ǉ����ꂽ�C���f�b�N�X���擾
            int index = _weaponEquipment.Count - 1;

            // UI���X�V
            _inventoryUI.UpdateAddWeaponInventoryUI(equipment, index);
        }
    }
    /// <summary>
      /// �������C���x���g������폜����
      /// </summary>
      /// <param name="equipment">����f�[�^</param>
    public void RemoveBodyEquipment(BodyEquipmentData equipment)
    {

        if (_bodyEquipment.Contains(equipment))
        {
            _bodyEquipment.Remove(equipment);
            // �ǉ����ꂽ�C���f�b�N�X���擾
            int index = _bodyEquipment.Count - 1;
            //_inventoryUI.UpdateRemoveEquipmentInventoryUI(equipment, index);
        }
    }
    /// <summary>
    /// ������C���x���g������폜����
    /// </summary>
    /// <param name="equipment">����f�[�^</param>
    public void RemoveWeaponEquipment(WeaponEquipmentData equipment)
    {

        if (_weaponEquipment.Contains(equipment))
        {
            _weaponEquipment.Remove(equipment);
            // �ǉ����ꂽ�C���f�b�N�X���擾
            int index = _weaponEquipment.Count - 1;
            //_inventoryUI.UpdateRemoveWeaponInventoryUI(equipment, index);
        }
    }
    /// <summary>
    /// �w�肵���C���x���g���X���b�g�ɑ����f�[�^��ǉ�����B
    /// </summary>
    /// <param name="equipment">�����f�[�^</param>
    /// <param name="index">�C���x���g���ԍ�</param>
    public void AddBodyEquipmentAt(BodyEquipmentData equipment, int index)
    {
        if (index < 0 || index > _bodyEquipment.Count)
        {
            return;
        }

        _bodyEquipment.Insert(index, equipment);

        // UI���X�V
        _inventoryUI.UpdateAddEquipmentInventoryUI(equipment, index);
    }

    /// <summary>
    /// �w�肵���C���x���g���X���b�g�ɓ����Ă��鑕���f�[�^���擾����
    /// </summary>
    /// <param name="index">�����C���x���g���ԍ�</param>
    /// <returns>�����f�[�^</returns>
    public BodyEquipmentData GetBodyEquipment(int index)
    {
        if (index >= 0 && index < _bodyEquipment.Count)
        {
            return _bodyEquipment[index];
        }
        return null;
    }
    /// <summary>
    /// �w�肵���C���x���g���X���b�g�ɓ����Ă��镐��f�[�^���擾����
    /// </summary>
    /// <param name="index">����C���x���g���ԍ�</param>
    /// <returns>����̃f�[�^</returns>
    public WeaponEquipmentData GetWeaponEquipment(int index)
    {
        if (index >= 0 && index < _weaponEquipment.Count)
        {
            return _weaponEquipment[index];
        }
        return null;
    }
}
