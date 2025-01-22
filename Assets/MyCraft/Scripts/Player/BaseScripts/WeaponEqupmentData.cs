using UnityEngine;
[CreateAssetMenu(fileName = "WeaponEquipmentData", menuName = "Equipment/Weapon")]
public class WeaponEqupmentData : ScriptableObject
{
    [SerializeField] private string _weaponName = "’Êí‘•”õ";
    [SerializeField] private int _attackPower;
    [SerializeField] private float _attackinterval;
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
    public WeaponType Weapon => _weaponType;
}
