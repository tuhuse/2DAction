using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ‘•”õ‚ÌƒCƒ“ƒxƒ“ƒgƒŠ
/// </summary>
public class EquipmentInventory : MonoBehaviour
{
    [SerializeField] private BodyEquipmentData _equipmentData;
    
    public PlayerStatus _playerStatus = new PlayerStatus();

    public static EquipmentInventory Instance { get; private set; }
    public BodyEquipmentData BodyEquipmentData { get; private set; }
    public BaseBodyEquipment BaseBodyEquipment { get; private set; }
    public bool IsChangeEquipment { get; private set; }
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
        // ‰Šú‰»
        _playerStatus.InitializeBodyEquipment(BaseBodyEquipment);
    }
    /// <summary>
    /// ‘•”õ‚ğØ‚è‘Ö‚¦‚é
    /// </summary>
    public void ChangeBodyEquiment(BodyEquipmentData bodyEquipmentData)
    {
        StartCoroutine(ChangeEquipment());
        BodyEquipmentData = bodyEquipmentData; 
        
    }
    /// <summary>
    /// ‰Šú‘•”õ‚Ìİ’è
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
    /// ‘•”õ‚Ìí—Ş‚É‰‚¶‚½‘•”õˆ—
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
            case BodyEquipmentData.EquipmentType.•‚—V:
                break;
        }
    }
    private IEnumerator ChangeEquipment()
    {
        IsChangeEquipment = true;
        yield return new WaitForSeconds(0.01f);
        EquimentType();
        IsChangeEquipment = false;
        
    }
}
