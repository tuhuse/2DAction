using UnityEngine;
[CreateAssetMenu(fileName = "WeaponEquipmentData", menuName = "Equipment/Weapon")]
public class WeaponEquipmentData : ScriptableObject
{
    [SerializeField] private string _weaponName = "’Êí‘•”õ";
    [SerializeField] private int _attackPower;
    [SerializeField] private float _attackinterval;
    [SerializeField] private float _attackingTime;
    [SerializeField] private Sprite _icon;
    [SerializeField] private GameObject _weaponObject;
    public enum WeaponType
    {
        MeleeWeapon,
        RangeWeapon,
        SummonWeapon,
    }
   [SerializeField] private WeaponType _weaponType;
    public string WeaponName => _weaponName;
    public int AttackPower => _attackPower;
    public float AttackInterval => _attackinterval;
    public float AttackingTime => _attackingTime;
    public Sprite Icon => _icon;
    public GameObject WeaponObject => _weaponObject;
    public WeaponType Weapon => _weaponType;
}
