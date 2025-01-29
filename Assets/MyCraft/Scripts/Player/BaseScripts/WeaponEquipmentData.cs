using UnityEngine;
[CreateAssetMenu(fileName = "WeaponEquipmentData", menuName = "Equipment/Weapon")]
public class WeaponEquipmentData : ScriptableObject
{
    [SerializeField] private string _weaponName = "’Êí‘•”õ";
    [SerializeField] private int _attackPower;
    [SerializeField] private float _attackinterval;
    [SerializeField] private Sprite _icon;
    public enum WeaponType
    {
        MeleeWeapon,
        RangeWeapon,
        SummonWeapon,
    }
   [SerializeField] private WeaponType _weaponType;
    public string WeaponName => _weaponName;
    public int AttackPower => _attackPower;
    public float AttackInterval => _attackPower;
    public Sprite Icon => _icon;
    public WeaponType Weapon => _weaponType;
}
