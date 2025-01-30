using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �C���x���g���t�h�X�V
/// </summary>
public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _equipmentSlotPrefab; // �����X���b�g�̃v���n�u
    [SerializeField] private GameObject _weaponSlotPrefab; // ����X���b�g�̃v���n�u
    [SerializeField] private Transform[] slotParents;           // �X���b�g��z�u����e�I�u�W�F�N�g
    [SerializeField] private int _equipmentSlotCount = 5;    //�����X���b�g��
    [SerializeField] private int _weaponSlotCount = 3;     // ����X���b�g��

    private const float SLOT_SPACING = 150f;

    private List<Image> _equipmentInventorySlots = new List<Image>();
    private List<Image> _weaponInventorySlots = new List<Image>();

    void Start()
    {
       
        GenerateEqupmentInventorySlots();
        GenerateWeaponInventorySlots();
    }

    /// <summary>
    /// �����C���x���g���̃X���b�g�𐶐�
    /// </summary>
    private void GenerateEqupmentInventorySlots()
    {
        for (int number = 0; number < _equipmentSlotCount; number++)
        {
            // �v���n�u����X���b�g�𐶐�
            GameObject slot = Instantiate(_equipmentSlotPrefab, slotParents[0]);

            // RectTransform���擾���Ĉʒu��ݒ�
            RectTransform slotTransform = slot.GetComponent<RectTransform>();
            if (slotTransform != null)
            {
                slotTransform.anchoredPosition = new Vector2(number * SLOT_SPACING, 0); // 150�Ԋu�Ŕz�u
            }

            // �X���b�g�����X�g�ɒǉ�
            _equipmentInventorySlots.Add(slot.GetComponent<Image>());
        }
    }
    /// <summary>
    /// ����C���x���g���̃X���b�g�̐���
    /// </summary>
    private void GenerateWeaponInventorySlots()
    {
        for (int number = 0; number < _weaponSlotCount; number++)
        {
            // �v���n�u����X���b�g�𐶐�
            GameObject slot = Instantiate(_weaponSlotPrefab, slotParents[1]);

            // RectTransform���擾���Ĉʒu��ݒ�
            RectTransform slotTransform = slot.GetComponent<RectTransform>();
            if (slotTransform != null)
            {
                slotTransform.anchoredPosition = new Vector2(number * 150, 0); // 150�Ԋu�Ŕz�u
            }

            // �X���b�g�����X�g�ɒǉ�
            _weaponInventorySlots.Add(slot.GetComponent<Image>());
        }
    }
    /// <summary>
    /// �����ύX��������UI�̍X�V
    /// </summary>
    /// <param name="bodyEquipmentData">�����f�[�^</param>
    /// <param name="index">�C���x���g�ԍ�</param>
    public void UpdateEquipmentInventoryUI(BodyEquipmentData bodyEquipmentData,int index)
    {
        if (index < 0 || index >= _equipmentInventorySlots.Count) return;
        _equipmentInventorySlots[index].sprite = bodyEquipmentData.Icon[0];
    }
    /// <summary>
    /// ����ύX��������UI�̍X�V
    /// </summary>
    /// <param name="weaponEquipmentData">����f�[�^</param>
    /// <param name="index">�C���x���g�ԍ�</param>
    public void UpdateWeaponInventoryUI(WeaponEquipmentData weaponEquipmentData, int index)
    {
        if (index < 0 || index >= _weaponInventorySlots.Count) return;
        _weaponInventorySlots[index].sprite = weaponEquipmentData.Icon;
    }

}
