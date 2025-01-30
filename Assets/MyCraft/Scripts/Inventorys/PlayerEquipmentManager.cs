using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �����̊Ǘ�
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
    /// ������؂�ւ���
    /// </summary>
    public void ChangeBodyEquipment(BodyEquipmentData bodyEquipmentData)
    {
        StartCoroutine(HandleBodyEquipmentChange(bodyEquipmentData));
        
    }/// <summary>
    ///�����؂�ւ���
    /// </summary>
    public void ChangeWeaponEquipment(WeaponEquipmentData weaponEquipmentData)
    {
        StartCoroutine(HandleWeaponEquipmentChange(weaponEquipmentData));
        
    }
    /// <summary>
    /// ���������̐ݒ�
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
    /// �����̎�ނɉ�������������
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
    /// ����̎�ނɉ���������
    /// </summary>
    private void ApplyWeaponType()
    {
        if (CurrentWeaponEquipment == null) return;

        switch (CurrentWeaponEquipment.Weapon)
        {
            case WeaponEquipmentData.WeaponType.MeleeWeapon:
                // �ߋ�������p�̏���
                break;
            case WeaponEquipmentData.WeaponType.RangeWeapon:
                // ����������p�̏���
                break;
            case WeaponEquipmentData.WeaponType.SummonWeapon:
                // ��������p�̏���
                break;
            default:
              
                break;
        }
    }
    /// <summary>
    /// �����ύX�̑ҋ@����
    /// </summary>
    private IEnumerator HandleBodyEquipmentChange(BodyEquipmentData newEquipment)
    {
        IsChangingEquipment = true;
        yield return new WaitForSeconds(WAIT_TIME);

        CurrentBodyEquipment = newEquipment;

        // null�`�F�b�N
        if (_playerSprite == null || CurrentBodyEquipment.Icon == null)
        {
            Debug.LogError("PlayerSprite �܂��� Icon �� null �ł��B");
            IsChangingEquipment = false;
            yield break;
        }

        // �z��̒����`�F�b�N
        int length = Mathf.Min(_playerSprite.Length, CurrentBodyEquipment.Icon.Length);
        for (int number = 0; number < length; number++)
        {
            _playerSprite[number].sprite = CurrentBodyEquipment.Icon[number];
        }

        ApplyBodyEquipmentType();
        IsChangingEquipment = false;
    }

    /// <summary>
    /// ����ύX�̑ҋ@����
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
