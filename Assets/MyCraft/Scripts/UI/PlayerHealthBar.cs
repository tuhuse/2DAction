using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider; // HPバー用のスライダー
    private PlayerStatus _playerStatus;           // プレイヤーのステータス

    // 初期化
    public void Initialize(PlayerStatus status)
    {
        _playerStatus = status;
        _healthSlider.maxValue = PlayerStatus. BASE_HEALTH; // スライダーの最大値を設定
        _healthSlider.value = PlayerStatus.BASE_HEALTH;   // スライダーの初期値を設定
    }

    // HPバーを更新
    public void UpdateHealthBar()
    {
        if (_playerStatus != null)
        {
            _healthSlider.value = _playerStatus.GetCurrentHealth(); // スライダーの値を現在HPに合わせる
        }
    }
}
