using UnityEngine;

[CreateAssetMenu(fileName = "BodyEquipmentData", menuName = "Equipment/Body")]
public class BodyEquipmentData : ScriptableObject
{
    [SerializeField] private string _equipmentName="’Êí‘•”õ";
    [SerializeField] private int _defense=10;
    [SerializeField] private float _moveSpeed=15f;
    [SerializeField] private float _jumpPower=5f;
    [SerializeField]private Sprite[] _icon;
    [SerializeField] private int _gravityScale;
    public enum EquipmentType
    {
        Begin,
        Soldier,
        Ancient,
        Purgatory,
        Curse,
        Sealed
        
    }
   [SerializeField] private EquipmentType _equipmentType;
    public string EquipmentName => _equipmentName;
    public int Defense => _defense;
    public float MoveSpeed => _moveSpeed;
    public float JumpPower=> _jumpPower;
    public int GravityScale => _gravityScale;
    public Sprite[] Icon => _icon;
    public int InitializeGravityScale => 1;
    public EquipmentType Equipment => _equipmentType;
}
