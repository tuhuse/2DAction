using UnityEngine;

public class Walk : MonoBehaviour, IWalk
{
    // 移動速度
    public float WalkSpeed { get; set; } = 10f;

    // Rigidbody2Dの参照
    private Rigidbody2D _playerRigidbody = null;

    void Start()
    {
        // Rigidbody2Dを取得
        _playerRigidbody = GetComponent<Rigidbody2D>();
        if (_playerRigidbody == null)
        {
            Debug.LogError("Rigidbody2Dがアタッチされていません！");
        }
    }

    public virtual void PlayerAction()
    {
        // Rigidbody2Dがnullでない場合に移動処理を実行
        if (_playerRigidbody != null)
        {
            _playerRigidbody.velocity = new Vector2(WalkSpeed, _playerRigidbody.velocity.y);
        }
    }
}
