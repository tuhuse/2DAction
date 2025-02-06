using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private PlayerController _playerController;
    [SerializeField]private GameObject _player;
    [TagSelector, SerializeField] private string _soldierEnemyTag;
    [TagSelector, SerializeField] private string _standEnemyTag;
    [TagSelector, SerializeField] private string _clearTag;
    [TagSelector, SerializeField] private string _deathTag;
    private const int THORN_LAYER_NUBER = 7;
    private int _thornDamage = 10;
    void Start()
    {
       
        _playerController = _player.GetComponent<PlayerController>();

       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_standEnemyTag))
        {
            _playerController.PlayerStatus.TakeDamage(collision.GetComponent<StandEnemyAttack>().AttackPower);

        }

        if (collision.gameObject.CompareTag(_soldierEnemyTag))
        {
            // ダメージを受けた処理
            _playerController.PlayerStatus.TakeDamage(collision.gameObject.GetComponent<SoldierEnemyAttack>().AttackPower);
        }
        if (collision.gameObject.layer == THORN_LAYER_NUBER)
        {
            // ダメージを受けた処理
            _playerController.PlayerStatus.TakeDamage(_thornDamage);
        }
        if (collision.gameObject.CompareTag(_clearTag))
        {
            SceneGameManager.Instance.OnGameClear();
        }
        if (collision.gameObject.CompareTag(_deathTag))
        {
            SceneGameManager.Instance.OnGameOver();
        }
    }

}
