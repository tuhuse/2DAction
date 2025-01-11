using UnityEngine;

[CreateAssetMenu(fileName = "BodyEquipmentData", menuName = "Equipment/Body")]
public class BodyEquipmentData : ScriptableObject
{
    [SerializeField] private string _equipmentName="’Êí‘•”õ";
    [SerializeField] private int _defense=10;
    [SerializeField] private float _moveSpeed=15f;
    [SerializeField] private float _jumpPower=5f;
    public enum EquipmentType
    {
        Nomal,
        Strong,
        •‚—V,
    }
   [SerializeField] private EquipmentType _equipmentType;
    public string EquipmentName => _equipmentName;
    public int Defense => _defense;
    public float MoveSpeed => _moveSpeed;
    public float JumpPower=> _jumpPower;
    public EquipmentType Equipment => _equipmentType;
}
