using UnityEngine;
[System.Serializable]
public class EnemyStatus : MonoBehaviour
{// ��{�X�e�[�^�X
    private const int BASE_HEALTH = 100;       // ��b�̗�
   
   private BaseEnemy _currentEnemyDeffence;

    //public float DamageMultiplier => _currentBodyEquipment != null ? _currentBodyEquipment.DamageMultiplier : 1f;

    // ���݂̗̑�
    private int _currentHealth;
    // �����ɂ��␳�l�i�v���p�e�B�œ��I�擾�j
    public int EnemyDefense
    {
        get
        {
            if (_currentEnemyDeffence != null)
            {
                return _currentEnemyDeffence.Defence;
            }
            else { return 0; }
        }
    }
    private void Start()
    {
        _currentEnemyDeffence = GetComponent<BaseEnemy>();
        _currentHealth = BASE_HEALTH;
    }
    // �_���[�W�v�Z
    public void TakeDamage(int damage)
    {
        // ���ۂ̖h��͂��v�Z
        int totalDefense = EnemyDefense;
        float effectiveDamage = Mathf.Max(0, damage - totalDefense); // �h��͂����Z
        //effectiveDamage *= DamageMultiplier; // �_���[�W�{����K�p
         // �̗͂�����
        if (effectiveDamage>damage)
        {
            _currentHealth--;
           
        }
        else
        {         
            _currentHealth -= Mathf.RoundToInt(effectiveDamage);
           
        }
       
        Debug.Log($"�_���[�W�󂯂�: {Mathf.RoundToInt(effectiveDamage)} ����HP: {_currentHealth}");
        GetCurrentHealth();
        // �̗͂�0�ȉ��Ȃ玀�S����
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    // ���S����
    private void Die()
    {
        Destroy(this.gameObject);
        // �Q�[���I�[�o�[�����⃊�X�|�[�������������ɒǉ�
    }

    // ���݂̗͎̑擾
    public int GetCurrentHealth()
    {
        return _currentHealth;
    }
}
