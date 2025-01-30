using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 装備の管理
/// </summary>
public class PlayerEquipmentManager : MonoBehaviour
{
    [SerializeField] private BodyEquipmentData _defaultBodyEquipmentData;
    [SerializeField] private WeaponEquipmentData _defaultWeaponData;
    [SerializeField] private SpriteRenderer[] _playerSprite;
    private PlayerController _playerController;

    private const float WAIT_TIME= 0.01f;
    

    public BaseBodyEquipment BaseBodyEquipment { get; private set; }
    public BaseWeapon EquipWeapon { get; private set; }
    public bool IsChangingEquipment { get; private set; }

    public BodyEquipmentData CurrentBodyEquipment { get; private set; }
    public WeaponEquipmentData CurrentWeaponEquipment { get; private set; }

    private void Start()
    {
        _playerController = GameObject.FindFirstObjectByType<PlayerController>();
        InitializeEquipment();
    }
    /// <summary>
    /// 装備を切り替える
    /// </summary>
    public void ChangeBodyEquipment(BodyEquipmentData bodyEquipmentData)
    {
        StartCoroutine(HandleBodyEquipmentChange(bodyEquipmentData));
        
    }/// <summary>
    ///武器を切り替える
    /// </summary>
    public void ChangeWeaponEquipment(WeaponEquipmentData weaponEquipmentData)
    {
        StartCoroutine(HandleWeaponEquipmentChange(weaponEquipmentData));
        
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
        if (CurrentWeaponEquipment == null) return;

        switch (CurrentWeaponEquipment.Weapon)
        {
            case WeaponEquipmentData.WeaponType.MeleeWeapon:
                // 近距離武器用の処理
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
    /// 装備変更の待機処理
    /// </summary>
    private IEnumerator HandleBodyEquipmentChange(BodyEquipmentData newEquipment)
    {
        IsChangingEquipment = true;
        yield return new WaitForSeconds(WAIT_TIME);

        CurrentBodyEquipment = newEquipment;

        // nullチェック
        if (_playerSprite == null || CurrentBodyEquipment.Icon == null)
        {
            Debug.LogError("PlayerSprite または Icon が null です。");
            IsChangingEquipment = false;
            yield break;
        }

        // 配列の長さチェック
        int length = Mathf.Min(_playerSprite.Length, CurrentBodyEquipment.Icon.Length);
        for (int number = 0; number < length; number++)
        {
            _playerSprite[number].sprite = CurrentBodyEquipment.Icon[number];
        }

        ApplyBodyEquipmentType();
        IsChangingEquipment = false;
    }

    /// <summary>
    /// 武器変更の待機処理
    /// </summary>
    private IEnumerator HandleWeaponEquipmentChange(WeaponEquipmentData newWeapon)
    {
        IsChangingEquipment = true;
        yield return new WaitForSeconds(WAIT_TIME);

        CurrentWeaponEquipment = newWeapon;
        ApplyWeaponType();

        IsChangingEquipment = false;
    }
}
