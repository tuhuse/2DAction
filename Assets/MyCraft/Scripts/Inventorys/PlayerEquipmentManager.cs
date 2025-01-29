using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �����̃C���x���g��
/// </summary>
public class PlayerEquipmentManager : MonoBehaviour
{
    [SerializeField] private BodyEquipmentData _defaultBodyEquipmentData;
    [SerializeField] private WeaponEquipmentData _defaultWeaponData;
    [SerializeField] private SpriteRenderer _playerSprite;
    private BodyEquipmentData _currentBodyEquipment;
    private WeaponEquipmentData _currentWeaponEquipment;
    private const float WAIT_TIME= 0.01f;
    

    public static PlayerEquipmentManager Instance { get; private set; }
    public PlayerStatus PlayerStatus { get; private set; } = new PlayerStatus();  
    public BaseBodyEquipment BaseBodyEquipment { get; private set; }
    public BaseWeapon EquipWeapon { get; private set; }
    public bool IsChangingEquipment { get; private set; }

    public BodyEquipmentData NowBodyEquipment { get; private set; }
    public WeaponEquipmentData NowWeapon { get; private set; }
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
            _currentBodyEquipment = _defaultBodyEquipmentData;
            NowBodyEquipment = _currentBodyEquipment;
            PlayerStatus.ChangeEquipment(BaseBodyEquipment);
        }
    }
    /// <summary>
    /// �����̎�ނɉ�������������
    /// </summary>
    private void ApplyBodyEquipmentType()
    {
        Destroy(BaseBodyEquipment);
        switch (_currentBodyEquipment.Equipment)
        {
            case BodyEquipmentData.EquipmentType.Nomal:
               
                BaseBodyEquipment = gameObject.AddComponent<NomalBodyEquipment>();
               
                break;
            case BodyEquipmentData.EquipmentType.Strong:
               
                BaseBodyEquipment = gameObject.AddComponent<StrongBodyEquipment>();
             
                
                break;
            case BodyEquipmentData.EquipmentType.hobber:
                break;
        }
        PlayerStatus.ChangeEquipment(BaseBodyEquipment);
    }
    /// <summary>
    /// ����̎�ނɉ���������
    /// </summary>
    private void ApplyWeaponType()
    {
        if (_currentWeaponEquipment == null) return;

        switch (_currentWeaponEquipment.Weapon)
        {
            case WeaponEquipmentData.WeaponType.MeleeWeapon:
                // �����[����p�̏���
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

        _currentBodyEquipment = newEquipment;
        _playerSprite.sprite = newEquipment.Icon;
        NowBodyEquipment = newEquipment;
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

        _currentWeaponEquipment = newWeapon;
        ApplyWeaponType();

        IsChangingEquipment = false;
    }
}
