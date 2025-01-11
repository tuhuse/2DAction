using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ‘•”õ‚ÌƒCƒ“ƒxƒ“ƒgƒŠ
/// </summary>
public class EquipmentInventory : MonoBehaviour
{
    [SerializeField] private BodyEquipmentData _equipmentData;
    PlayerStatus _playerStatus = new PlayerStatus();

    public static EquipmentInventory Instance { get; private set; }
    public BodyEquipmentData BodyEquipment { get; private set; }
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
        BodyEquipment = _equipmentData;
        // ‰Šú‰»
        _playerStatus.Initialize(BaseBodyEquipment);
    }
    public void ChangeBodyEquiment(BodyEquipmentData bodyEquipmentData)
    {
        BodyEquipment = bodyEquipmentData; 
        EquimentType();
    }
    public void NullEquipment()
    {
        if (BaseBodyEquipment == null)
        {
            BaseBodyEquipment = gameObject.AddComponent<NomalBodyEquipment>();
            BodyEquipment = _equipmentData;
            _playerStatus.ChangeEquipment(BaseBodyEquipment);
        }
      
    }
    private void EquimentType()
    {
        switch (BodyEquipment.Equipment)
        {
            case BodyEquipmentData.EquipmentType.Nomal:
                Destroy(BaseBodyEquipment);
                BaseBodyEquipment = gameObject.AddComponent<NomalBodyEquipment>();
                _playerStatus.ChangeEquipment(BaseBodyEquipment);
                break;
            case BodyEquipmentData.EquipmentType.Strong:
                break;
            case BodyEquipmentData.EquipmentType.•‚—V:
                break;
        }
    }

}
