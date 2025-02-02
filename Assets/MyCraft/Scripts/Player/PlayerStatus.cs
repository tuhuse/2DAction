using UnityEngine;

[System.Serializable]
public class PlayerStatus
{
    // 基本ステータス
    public const int BASE_HEALTH = 100;       // 基礎体力
    private const int BASE_DEFENSE = 5;       // 基礎防御力

    // 現在装備している防具
    private BaseBodyEquipment _currentBodyEquipment;
    private PlayerHealthBar _playerHealthBar;

    //public float DamageMultiplier => _currentBodyEquipment != null ? _currentBodyEquipment.DamageMultiplier : 1f;

    // 現在の体力
    private int _currentHealth;
    // 装備による補正値（プロパティで動的取得）
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
    // 初期化処理
    public void InitializeBodyEquipment(BaseBodyEquipment initialEquipment)
    {
        _currentHealth = BASE_HEALTH;
        _currentBodyEquipment = initialEquipment;
    }
    public void InitializeHealthBar(PlayerHealthBar healthBar)
    {
        _currentHealth = BASE_HEALTH;
        _playerHealthBar = healthBar;

        if (healthBar != null)
        {
            healthBar.Initialize(this); // HPバーを初期化
        }
    }
    // 装備を変更するメソッド
    public void ChangeEquipment(BaseBodyEquipment newEquipment)
    {
        _currentBodyEquipment = newEquipment;
        
    }

    // ダメージ計算
    public void TakeDamage(int damage)
    {
        // 実際の防御力を計算
        int totalDefense = BASE_DEFENSE + ArmorDefense;
        float effectiveDamage = Mathf.Max(0, damage - totalDefense); // 防御力を減算
        //effectiveDamage *= DamageMultiplier; // ダメージ倍率を適用
        if (effectiveDamage == 0)
        {
            effectiveDamage = 1;
        }
        // 体力を減少
        _currentHealth -= Mathf.RoundToInt(effectiveDamage);
        Debug.Log($"ダメージ受けた: {Mathf.RoundToInt(effectiveDamage)} 現在HP: {_currentHealth}");
        GetCurrentHealth();
        if (_playerHealthBar != null)
        {
            _playerHealthBar.UpdateHealthBar(); // HPバーを更新
        }

        // 体力が0以下なら死亡処理
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    // 死亡処理
    private void Die()
    {
        SceneGameManager.Instance.OnGameOver();
    }

    // 現在の体力取得
    public int GetCurrentHealth()
    {
        return _currentHealth;
    }
}
