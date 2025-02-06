using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �C���x���g���t�h�X�V
/// </summary>
public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _equipmentSlotPrefab; // �����X���b�g�̃v���n�u
    [SerializeField] private GameObject _equipmentFramePrefab; // �����t���[���̃v���n�u
    [SerializeField] private GameObject _weaponSlotPrefab; // ����X���b�g�̃v���n�u
    [SerializeField] private GameObject _weaponFramePrefab; // ����t���[���̃v���n�u
    [SerializeField] private Transform[] slotParents;           // �X���b�g��z�u����e�I�u�W�F�N�g
    [SerializeField] private int _equipmentSlotCount = 5;    //�����X���b�g��
    [SerializeField] private int _weaponSlotCount = 3;     // ����X���b�g��

    private const float SLOT_SPACING = 150f;

   [SerializeField] private List<Image> _equipmentInventorySlots = new List<Image>();
   [SerializeField] private List<Image> _weaponInventorySlots = new List<Image>();
    private List<GameObject> _equipmentInventoryFrame = new List<GameObject>();
    private List<GameObject> _weaponInventoryFrame = new List<GameObject>();

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

            // �v���n�u����ӂ�[�ނ𐶐�
            GameObject frameSlot = Instantiate(_equipmentFramePrefab, slotParents[0]);
            // �v���n�u����X���b�g�𐶐�
            GameObject slot = Instantiate(_equipmentSlotPrefab, slotParents[0]);
            // RectTransform���擾���Ĉʒu��ݒ�
            RectTransform slotTransform = slot.GetComponent<RectTransform>();
            RectTransform frameTransform = frameSlot.GetComponent<RectTransform>();
            if (slotTransform != null && frameTransform != null)
            {
                slotTransform.anchoredPosition = new Vector2(number * SLOT_SPACING, 0); // 150�Ԋu�Ŕz�u
                frameTransform.anchoredPosition = new Vector2(number * SLOT_SPACING, 0); // 150�Ԋu�Ŕz�u
            }

            // �X���b�g�����X�g�ɒǉ�
            _equipmentInventorySlots.Add(slot.GetComponent<Image>());
            _equipmentInventoryFrame.Add(frameSlot);

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
            GameObject frameSlot = Instantiate(_weaponFramePrefab, slotParents[1]);
            // �v���n�u����X���b�g�𐶐�
            GameObject slot = Instantiate(_weaponSlotPrefab, slotParents[1]);

            // RectTransform���擾���Ĉʒu��ݒ�
            RectTransform slotTransform = slot.GetComponent<RectTransform>();
            RectTransform frameTransform = frameSlot.GetComponent<RectTransform>();

            if (slotTransform != null && frameTransform != null)
            {
                slotTransform.anchoredPosition = new Vector2(number * SLOT_SPACING, 0); // 150�Ԋu�Ŕz�u
                frameTransform.anchoredPosition = new Vector2(number * SLOT_SPACING, 0); // 150�Ԋu�Ŕz�u

            }

            // �X���b�g�����X�g�ɒǉ�
            _weaponInventorySlots.Add(slot.GetComponent<Image>());
            // �X���b�g�����X�g�ɒǉ�
            _weaponInventoryFrame.Add(frameSlot);
        }
    }
    /// <summary>
    /// �������莞��UI�̍X�V
    /// </summary>
    /// <param name="bodyEquipmentData">�����f�[�^</param>
    /// <param name="index">�C���x���g�ԍ�</param>
    public void UpdateAddEquipmentInventoryUI(BodyEquipmentData bodyEquipmentData, int index)
    {
        if (index < 0 || index >= _equipmentInventorySlots.Count)
        {
            return;
        }
        if (!_equipmentInventorySlots[index].enabled)
        {
            _equipmentInventorySlots[index].enabled = true;
        }
        _equipmentInventorySlots[index].sprite = bodyEquipmentData.Icon[8];
    }
    /// <summary>
     /// �����ύX��������UI�̍X�V
     /// </summary>
     /// <param name="bodyEquipmentData">�����f�[�^</param>
     /// <param name="index">�C���x���g�ԍ�</param>
    //public void UpdateRemoveEquipmentInventoryUI(BodyEquipmentData bodyEquipmentData, int index)
    //{
    //    if (index < 0 || index >= _equipmentInventorySlots.Count)
    //    {
    //        return;
    //    }
    //    _equipmentInventorySlots[index].sprite =null;
    //}

    /// <summary>
    /// ������莞��UI�̍X�V
    /// </summary>
    /// <param name="weaponEquipmentData">����f�[�^</param>
    /// <param name="index">�C���x���g�ԍ�</param>
    public void UpdateAddWeaponInventoryUI(WeaponEquipmentData weaponEquipmentData, int index)
    {
        if (index < 0 || index >= _weaponInventorySlots.Count)
        {
            return;
        }
        if (!_weaponInventorySlots[index].enabled)
        {
            _weaponInventorySlots[index].enabled = true;
        }
        _weaponInventorySlots[index].sprite = weaponEquipmentData.Icon;
    }

    /// <summary>
    /// ����ύX��������UI�̍X�V
    /// </summary>
    /// <param name="weaponEquipmentData">�����f�[�^</param>
    /// <param name="index">�C���x���g�ԍ�</param>
    //public void UpdateRemoveWeaponInventoryUI(WeaponEquipmentData weaponEquipmentData, int index)
    //{
    //    if (index < 0 || index >= _equipmentInventorySlots.Count)
    //    {
    //        return;
    //    }
    //    _weaponInventorySlots[index].sprite = null;

    //}
}
