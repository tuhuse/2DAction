using UnityEngine;

[System.Serializable]
public class PlayerStatus
{
    // 基本ステータス
    private const int BASE_HEALTH = 100;       // 基礎体力
    private const int BASE_DIFENSE = 10;      // 基礎防御力

    private BaseBodyEquipment _baseBodyEquipment;
    // 装備による補正値
    public int ArmorDefense = 0;      // 装備防御力
    public float damageMultiplier = 1f; // ダメージ倍率（例: 軽装なら1.2倍）

    // 現在の体力
    private int currentHealth;


    // 初期化処理
    public void Initialize()
    {
        currentHealth = BASE_HEALTH;
    }

    // ダメージ計算
    public void TakeDamage(int damage)
    {
        // 実際の防御力を計算
        int totalDefense = BASE_DIFENSE + ArmorDefense;
        float effectiveDamage = Mathf.Max(0, damage - totalDefense); // 防御力を減算
        effectiveDamage *= damageMultiplier; // ダメージ倍率を適用

        // 体力を減少
        currentHealth -= Mathf.RoundToInt(effectiveDamage);
        Debug.Log($"ダメージ受けた: {Mathf.RoundToInt(effectiveDamage)} 現在HP: {currentHealth}");

        // 体力が0以下なら死亡処理
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // 死亡処理
    private void Die()
    {
        Debug.Log("プレイヤー死亡");
        // ゲームオーバー処理やリスポーン処理をここに追加
    }

    // 現在の体力取得
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
