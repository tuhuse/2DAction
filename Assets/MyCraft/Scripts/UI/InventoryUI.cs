using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _equpmentSlotPrefab; // �����X���b�g�̃v���n�u
    [SerializeField] private GameObject _weaponSlotPrefab; // ����X���b�g�̃v���n�u
    [SerializeField] private Transform[] slotParent;           // �X���b�g��z�u����e�I�u�W�F�N�g
    [SerializeField] private int _equpmentSlotCount = 5;    //�����X���b�g��
    [SerializeField] private int _weaponSlotCount = 3;     // ����X���b�g��

    private List<Image> _equpmentInventorySlots = new List<Image>();
    private List<Image> _weaponInventorySlots = new List<Image>();

    void Start()
    {
        GenerateEqupmentInventorySlots();
        GenerateWeaponInventorySlots();
    }

    /// <summary>
    /// �C���x���g���̘g�𐶐�
    /// </summary>
    private void GenerateEqupmentInventorySlots()
    {
        for (int number = 0; number < _equpmentSlotCount; number++)
        {
            // �v���n�u����X���b�g�𐶐�
            GameObject slot = Instantiate(_equpmentSlotPrefab, slotParent[0]);

            // RectTransform���擾���Ĉʒu��ݒ�
            RectTransform slotTransform = slot.GetComponent<RectTransform>();
            if (slotTransform != null)
            {
                slotTransform.anchoredPosition = new Vector2(number * 150, 0); // 150�Ԋu�Ŕz�u
            }

            // �X���b�g�����X�g�ɒǉ�
            _equpmentInventorySlots.Add(slot.GetComponent<Image>());
        }
    }

    private void GenerateWeaponInventorySlots()
    {
        for (int number = 0; number < _weaponSlotCount; number++)
        {
            // �v���n�u����X���b�g�𐶐�
            GameObject slot = Instantiate(_weaponSlotPrefab, slotParent[1]);

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
    public void UpdateEquipmentInventoryUI(BodyEquipmentData bodyEquipmentData,int index)
    {
        _equpmentInventorySlots[index].sprite = bodyEquipmentData.Icon;
    }
    public void UpdateWeaponInventoryUI(WeaponEqupmentData weaponEquipmentData, int index)
    {
        _equpmentInventorySlots[index].sprite = weaponEquipmentData.Icon;
    }

}
