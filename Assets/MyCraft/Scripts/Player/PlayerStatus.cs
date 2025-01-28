using UnityEngine;

[System.Serializable]
public class PlayerStatus
{
    // ��{�X�e�[�^�X
    public const int BASE_HEALTH = 100;       // ��b�̗�
    private const int BASE_DEFENSE = 5;       // ��b�h���

    // ���ݑ������Ă���h��
    private BaseBodyEquipment _currentBodyEquipment;
    private PlayerHealthBar _playerHealthBar;

    //public float DamageMultiplier => _currentBodyEquipment != null ? _currentBodyEquipment.DamageMultiplier : 1f;

    // ���݂̗̑�
    private int currentHealth;
    // �����ɂ��␳�l�i�v���p�e�B�œ��I�擾�j
    public int ArmorDefense {
        get
        {
            if (_currentBodyEquipment != null)
            {
                return _currentBodyEquipment.Deffence;
            }
            else { return 0; }
        } 
    }
    // ����������
    public void InitializeBodyEquipment(BaseBodyEquipment initialEquipment)
    {
        currentHealth = BASE_HEALTH;
        _currentBodyEquipment = initialEquipment;
    }
    public void InitializeHealthBar(PlayerHealthBar healthBar)
    {
        currentHealth = BASE_HEALTH;
        _playerHealthBar = healthBar;

        if (healthBar != null)
        {
            healthBar.Initialize(this); // HP�o�[��������
        }
    }
    // ������ύX���郁�\�b�h
    public void ChangeEquipment(BaseBodyEquipment newEquipment)
    {
        _currentBodyEquipment = newEquipment;
        
    }

    // �_���[�W�v�Z
    public void TakeDamage(int damage)
    {
        // ���ۂ̖h��͂��v�Z
        int totalDefense = BASE_DEFENSE + ArmorDefense;
        float effectiveDamage = Mathf.Max(0, damage - totalDefense); // �h��͂����Z
        //effectiveDamage *= DamageMultiplier; // �_���[�W�{����K�p
        if (effectiveDamage == 0)
        {
            effectiveDamage = 1;
        }
        // �̗͂�����
        currentHealth -= Mathf.RoundToInt(effectiveDamage);
        Debug.Log($"�_���[�W�󂯂�: {Mathf.RoundToInt(effectiveDamage)} ����HP: {currentHealth}");
        GetCurrentHealth();
        if (_playerHealthBar != null)
        {
            _playerHealthBar.UpdateHealthBar(); // HP�o�[���X�V
        }

        // �̗͂�0�ȉ��Ȃ玀�S����
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // ���S����
    private void Die()
    {
        SceneGameManager.Instance.OnGameOver();
    }

    // ���݂̗͎̑擾
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
