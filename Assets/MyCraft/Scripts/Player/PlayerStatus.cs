using UnityEngine;

[System.Serializable]
public class PlayerStatus
{
    // ��{�X�e�[�^�X
    public int _baseHealth = 100;       // ��b�̗�
    public int _baseDefense = 10;      // ��b�h���

    // �����ɂ��␳�l
    public int armorDefense = 0;      // �����h���
    public float damageMultiplier = 1f; // �_���[�W�{���i��: �y���Ȃ�1.2�{�j

    // ���݂̗̑�
    private int currentHealth;

    // ����������
    public void Initialize()
    {
        currentHealth = _baseHealth;
    }

    // �_���[�W�v�Z
    public void TakeDamage(int damage)
    {
        // ���ۂ̖h��͂��v�Z
        int totalDefense = _baseDefense + armorDefense;
        float effectiveDamage = Mathf.Max(0, damage - totalDefense); // �h��͂����Z
        effectiveDamage *= damageMultiplier; // �_���[�W�{����K�p

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
