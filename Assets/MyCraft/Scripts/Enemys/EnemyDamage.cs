
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private EnemyStatus _enemyStatus;
    private Player _player;
    private Rigidbody2D _rb;
    [TagSelector, SerializeField] private string _playerTag;
    [TagSelector, SerializeField] private string _sordTag;
    [SerializeField] private float knockbackForce = 20f; // ノックバックの強さを調整

    void Start()
    {
        _enemyStatus = GetComponent<EnemyStatus>();
        _player = GameObject.FindFirstObjectByType<Player>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_sordTag))
        {
            if (this.gameObject.CompareTag("StandEnemy"))
            {
                _enemyStatus.TakeDamage(_player.Weapon.AttackPower);

            }
            else
            {
                
                _enemyStatus.TakeDamage(_player.Weapon.AttackPower);
                
                // ノックバックの方向を計算（敵 → プレイヤーの逆方向）
                Vector2 knockbackDirection = (transform.position - _player.transform.position).normalized;

                // Rigidbody2D に力を加える
                _rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            }
          
        }
    }
}
