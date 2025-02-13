using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// プレイヤーの装備を管理するクラス
/// 装備の切り替えや初期装備の設定を行う
/// </summary>
public class PlayerEquipmentManager : MonoBehaviour
{
    [SerializeField] private BodyEquipmentData _defaultBodyEquipmentData=default;
    [SerializeField] private WeaponEquipmentData _defaultWeaponData=default;
    [SerializeField] private SpriteRenderer[] _playerSprite=default;
    private PlayerController _playerController=default;
    /// <summary>
    /// 現在の装備
    /// </summary>
    public BaseBodyEquipment BaseBodyEquipment { get; private set; }
    /// <summary>
    /// 現在の武器
    /// </summary>
    public BaseWeapon EquipWeapon { get; private set; }
    /// <summary>
    /// プレイヤーの射程距離
    /// </summary>
    public BaseAttackRange AttackRange { get; private set; }
    /// <summary>
    ///装備データ
    /// </summary>
    public BodyEquipmentData CurrentBodyEquipment { get; private set; }
    /// <summary>
    ///武器データ
    /// </summary>
    public WeaponEquipmentData CurrentWeaponEquipment { get; private set; }

    private void Start()
    {
        _playerController = GameObject.FindFirstObjectByType<PlayerController>();
        InitializeEquipment();
        InitializeWeapon();
    }
    /// <summary>
    /// 装備を変更する
    /// </summary>
    /// <param name="bodyEquipmentData">装備データ</param>
    public void ChangeBodyEquipment(BodyEquipmentData bodyEquipmentData)
    {
        HandleBodyEquipmentChange(bodyEquipmentData);
    }
    /// <summary>
    /// 武器を変更する
    /// </summary>
    /// <param name="weaponEquipmentData">武器データ</param>
    public void ChangeWeaponEquipment(WeaponEquipmentData weaponEquipmentData)
    {
        HandleWeaponEquipmentChange(weaponEquipmentData);

    }
    /// <summary>
    /// 初期装備の設定
    /// </summary>
    public void InitializeEquipment()
    {
        if (BaseBodyEquipment == null)
        {
            BaseBodyEquipment = gameObject.AddComponent<NomalBodyEquipment>();
            CurrentBodyEquipment = _defaultBodyEquipmentData;
            _playerController.PlayerStatus.ChangeEquipment(BaseBodyEquipment);
        }
    }  public void InitializeWeapon()
    {
        if (EquipWeapon == null)
        {
            EquipWeapon = gameObject.AddComponent<SordWeapon>();
           
            CurrentWeaponEquipment = _defaultWeaponData;
        }
        if (AttackRange == null)
        {
            AttackRange = gameObject.AddComponent<SordAttackRange>();
        }
    }
    /// <summary>
    /// 装備の種類に応じた装備処理
    /// </summary>
    private void ApplyBodyEquipmentType()
    {
        if (BaseBodyEquipment != null)
        {
            Destroy(BaseBodyEquipment);
        }
        switch (CurrentBodyEquipment.Equipment)
        {
            case BodyEquipmentData.EquipmentType.Begin:

                BaseBodyEquipment = gameObject.AddComponent<NomalBodyEquipment>();

                break;
            case BodyEquipmentData.EquipmentType.Soldier:

                BaseBodyEquipment = gameObject.AddComponent<StrongBodyEquipment>();


                break;
            case BodyEquipmentData.EquipmentType.Ancient:

                break;
            case BodyEquipmentData.EquipmentType.Curse:
                break;
            case BodyEquipmentData.EquipmentType.Sealed:
                break;
        }
        _playerController.PlayerStatus.ChangeEquipment(BaseBodyEquipment);
    }
    /// <summary>
    /// 武器の種類に応じた処理
    /// </summary>
    private void ApplyWeaponType()
    {
        if (CurrentWeaponEquipment != null)
        {
            Destroy(EquipWeapon);
        }
        if (AttackRange !=null)
        {
            Destroy(AttackRange);
        }
        switch (CurrentWeaponEquipment.Weapon)
        {
            case WeaponEquipmentData.WeaponType.MeleeWeapon:

                EquipWeapon = gameObject.AddComponent<SordWeapon>();
                AttackRange = gameObject.AddComponent<SordAttackRange>();
                
                break;
            case WeaponEquipmentData.WeaponType.RangeWeapon:
                // 遠距離武器用の処理
                break;
            case WeaponEquipmentData.WeaponType.SummonWeapon:
                // 召喚武器用の処理
                break;
            default:

                break;
        }
    }
    /// <summary>
    /// /装備変更時の処理
    /// </summary>
    /// <param name="newEquipment">新しい装備データ</param>
    private void HandleBodyEquipmentChange(BodyEquipmentData newEquipment)
    {
        CurrentBodyEquipment = newEquipment;
        // スプライトを新しい装備に変更
        for (int number = 0; number < _playerSprite.Length; number++)
        {
            _playerSprite[number].sprite = CurrentBodyEquipment.Icon[number];
        }
        ApplyBodyEquipmentType();
    }

    /// <summary>
    /// 武器変更の処理
    /// </summary>
    /// <param name="newWeapon">新しい武器データ</param>
    private void HandleWeaponEquipmentChange(WeaponEquipmentData newWeapon)
    {
        CurrentWeaponEquipment = newWeapon;
        ApplyWeaponType();
    }
}
