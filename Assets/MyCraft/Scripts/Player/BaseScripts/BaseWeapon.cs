using UnityEngine;

/// <summary>
/// ïêäÌ
/// </summary>
public abstract class BaseWeapon : MonoBehaviour
{
    protected WeaponEquipmentData _weaponData = default;
    protected GameObject _weapon = default;
    protected bool _isAttackCoolDown = false;
    protected GameObject _player;
    protected float AttackInterval => _weaponData.AttackInterval;
    protected float AttackingTime => _weaponData.AttackingTime;
    public int AttackPower => _weaponData.AttackPower;
    protected void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        _weaponData = _player.GetComponent<Player>().GetWeaponData();
        WeaponTypeSwitch(_weaponData);
    }
    public void TryAttack()
    {
        if (!_isAttackCoolDown)
        {
            Attack();
        }
    }
    public abstract void Attack();
    private void WeaponTypeSwitch(WeaponEquipmentData weapon)
    {
        switch (_weaponData.Weapon)
        {
            case WeaponEquipmentData.WeaponType.MeleeWeapon:
                _weapon = GameObject.FindGameObjectWithTag("Sord");
                _weapon.SetActive(false);
                break;
            case WeaponEquipmentData.WeaponType.RangeWeapon:
                _weapon = GameObject.FindGameObjectWithTag("Range");
                _weapon.SetActive(false);
                break;
            case WeaponEquipmentData.WeaponType.SummonWeapon:

                break;
        }
    }
}
