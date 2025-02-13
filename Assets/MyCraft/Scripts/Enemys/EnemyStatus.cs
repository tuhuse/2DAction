using UnityEngine;
[System.Serializable]
public class EnemyStatus : MonoBehaviour
{// 基本ステータス
    private const int BASE_HEALTH = 100;       // 基礎体力
   
   private BaseEnemy _currentEnemyDeffence;

    //public float DamageMultiplier => _currentBodyEquipment != null ? _currentBodyEquipment.DamageMultiplier : 1f;

    // 現在の体力
    private int _currentHealth;
    // 装備による補正値（プロパティで動的取得）
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
    // ダメージ計算
    public void TakeDamage(int damage)
    {
        // 実際の防御力を計算
        int totalDefense = EnemyDefense;
        float effectiveDamage = Mathf.Max(0, damage - totalDefense); // 防御力を減算
        //effectiveDamage *= DamageMultiplier; // ダメージ倍率を適用
         // 体力を減少
        if (effectiveDamage>damage)
        {
            _currentHealth--;
           
        }
        else
        {         
            _currentHealth -= Mathf.RoundToInt(effectiveDamage);
           
        }
       
        Debug.Log($"ダメージ受けた: {Mathf.RoundToInt(effectiveDamage)} 現在HP: {_currentHealth}");
        GetCurrentHealth();
        // 体力が0以下なら死亡処理
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    // 死亡処理
    private void Die()
    {
        Destroy(this.gameObject);
        // ゲームオーバー処理やリスポーン処理をここに追加
    }

    // 現在の体力取得
    public int GetCurrentHealth()
    {
        return _currentHealth;
    }
}
