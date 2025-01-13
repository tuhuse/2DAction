using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �����̃C���x���g��
/// </summary>
public class EquipmentInventory : MonoBehaviour
{
    [SerializeField] private BodyEquipmentData _equipmentData;
    PlayerStatus _playerStatus = new PlayerStatus();

    public static EquipmentInventory Instance { get; private set; }
    public BodyEquipmentData BodyEquipmentData { get; private set; }
    public BaseBodyEquipment BaseBodyEquipment { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); 
            return;
        }
    }

    private void Start()
    {
        InitializeEquipment();
        BodyEquipmentData = _equipmentData;
        // ������
        _playerStatus.Initialize(BaseBodyEquipment);
    }
    /// <summary>
    /// ������؂�ւ���
    /// </summary>
    public void ChangeBodyEquiment(BodyEquipmentData bodyEquipmentData)
    {
        BodyEquipmentData = bodyEquipmentData; 
        EquimentType();
    }
    /// <summary>
    /// ���������̐ݒ�
    /// </summary>
    public void InitializeEquipment()
    {
        if (BaseBodyEquipment == null)
        {
            BaseBodyEquipment = gameObject.AddComponent<NomalBodyEquipment>();
            BodyEquipmentData = _equipmentData;
            _playerStatus.ChangeEquipment(BaseBodyEquipment);
        }
      
    }
    /// <summary>
    /// �����̎�ނɉ�������������
    /// </summary>
    private void EquimentType()
    {
        switch (BodyEquipmentData.Equipment)
        {
            case BodyEquipmentData.EquipmentType.Nomal:
                Destroy(BaseBodyEquipment);
                BaseBodyEquipment = gameObject.AddComponent<NomalBodyEquipment>();
                _playerStatus.ChangeEquipment(BaseBodyEquipment);
                Debug.Log("kutabare");
                break;
            case BodyEquipmentData.EquipmentType.Strong:
                Destroy(BaseBodyEquipment);
                BaseBodyEquipment = gameObject.AddComponent<StrongBodyEquipment>();
                _playerStatus.ChangeEquipment(BaseBodyEquipment);
                Debug.Log("iei");
                break;
            case BodyEquipmentData.EquipmentType.���V:
                break;
        }
    }

}
