using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// �v���C���[�̑������Ǘ�����N���X
/// �����̐؂�ւ��⏉�������̐ݒ���s��
/// </summary>
public class PlayerEquipmentManager : MonoBehaviour
{
    [SerializeField] private BodyEquipmentData _defaultBodyEquipmentData=default;
    [SerializeField] private WeaponEquipmentData _defaultWeaponData=default;
    [SerializeField] private SpriteRenderer[] _playerSprite=default;
    private PlayerController _playerController=default;
    /// <summary>
    /// ���݂̑���
    /// </summary>
    public BaseBodyEquipment BaseBodyEquipment { get; private set; }
    /// <summary>
    /// ���݂̕���
    /// </summary>
    public BaseWeapon EquipWeapon { get; private set; }
    /// <summary>
    /// �v���C���[�̎˒�����
    /// </summary>
    public BaseAttackRange AttackRange { get; private set; }
    /// <summary>
    ///�����f�[�^
    /// </summary>
    public BodyEquipmentData CurrentBodyEquipment { get; private set; }
    /// <summary>
    ///����f�[�^
    /// </summary>
    public WeaponEquipmentData CurrentWeaponEquipment { get; private set; }

    private void Start()
    {
        _playerController = GameObject.FindFirstObjectByType<PlayerController>();
        InitializeEquipment();
        InitializeWeapon();
    }
    /// <summary>
    /// ������ύX����
    /// </summary>
    /// <param name="bodyEquipmentData">�����f�[�^</param>
    public void ChangeBodyEquipment(BodyEquipmentData bodyEquipmentData)
    {
        HandleBodyEquipmentChange(bodyEquipmentData);
    }
    /// <summary>
    /// �����ύX����
    /// </summary>
    /// <param name="weaponEquipmentData">����f�[�^</param>
    public void ChangeWeaponEquipment(WeaponEquipmentData weaponEquipmentData)
    {
        HandleWeaponEquipmentChange(weaponEquipmentData);

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
    /// /�����ύX���̏���
    /// </summary>
    /// <param name="newEquipment">�V���������f�[�^</param>
    private void HandleBodyEquipmentChange(BodyEquipmentData newEquipment)
    {
        CurrentBodyEquipment = newEquipment;
        // �X�v���C�g��V���������ɕύX
        for (int number = 0; number < _playerSprite.Length; number++)
        {
            _playerSprite[number].sprite = CurrentBodyEquipment.Icon[number];
        }
        ApplyBodyEquipmentType();
    }

    /// <summary>
    /// ����ύX�̏���
    /// </summary>
    /// <param name="newWeapon">�V��������f�[�^</param>
    private void HandleWeaponEquipmentChange(WeaponEquipmentData newWeapon)
    {
        CurrentWeaponEquipment = newWeapon;
        ApplyWeaponType();
    }
}
