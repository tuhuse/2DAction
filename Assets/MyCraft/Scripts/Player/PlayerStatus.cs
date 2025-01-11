using UnityEngine;

[System.Serializable]
public class PlayerStatus
{
    // ��{�X�e�[�^�X
    private const int BASE_HEALTH = 100;       // ��b�̗�
    private const int BASE_DEFENSE = 10;       // ��b�h���

    // ���ݑ������Ă���h��
    private BaseBodyEquipment _currentBodyEquipment;


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
    public void Initialize(BaseBodyEquipment initialEquipment)
    {
        currentHealth = BASE_HEALTH;
        _currentBodyEquipment = initialEquipment;
    }

    // ������ύX���郁�\�b�h
    public void ChangeEquipment(BaseBodyEquipment newEquipment)
    {
        _currentBodyEquipment = newEquipment;
        Debug.Log($"������ύX: {_currentBodyEquipment.name}");
    }

    // �_���[�W�v�Z
    public void TakeDamage(int damage)
    {
        // ���ۂ̖h��͂��v�Z
        int totalDefense = BASE_DEFENSE + ArmorDefense;
        float effectiveDamage = Mathf.Max(0, damage - totalDefense); // �h��͂����Z
        //effectiveDamage *= DamageMultiplier; // �_���[�W�{����K�p

        // �̗͂�����
        currentHealth -= Mathf.RoundToInt(effectiveDamage);
        Debug.Log($"�_���[�W�󂯂�: {Mathf.RoundToInt(effectiveDamage)} ����HP: {currentHealth}");

        // �̗͂�0�ȉ��Ȃ玀�S����
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // ���S����
    private void Die()
    {
        Debug.Log("�v���C���[���S");
        // �Q�[���I�[�o�[�����⃊�X�|�[�������������ɒǉ�
    }

    // ���݂̗͎̑擾
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
