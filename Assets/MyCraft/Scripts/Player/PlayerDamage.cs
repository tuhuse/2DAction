using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private GameObject _standEnemy;
    private const int THORN_LAYER_NUBER = 7;
    private int _thornDamage = 10;
    void Start()
    {
        _standEnemy = GameObject.FindGameObjectWithTag("StandEnemy");
        PlayerCollisionDetector collisionDetector = GetComponent<PlayerCollisionDetector>();
        if (collisionDetector != null)
        {
            collisionDetector.OnPlayerCollisionEnter += HandleCollisionEnter;
        }
        PlayerCollisionDetector triggerDetector = GetComponent<PlayerCollisionDetector>();
        if (collisionDetector != null)
        {
            triggerDetector.OnPlayerTriggerEnter += HandleTriggerEnter;
        }
    }

    private void HandleCollisionEnter(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SoldierEnemy"))
        {
            // �_���[�W���󂯂�����
            PlayerEquipmentManager.Instance.PlayerStatus.TakeDamage(collision.gameObject.GetComponent<SoldierEnemyAttack>().AttackPower);
        }
        if (collision.gameObject.CompareTag("StandEnemy"))
        {
            // �_���[�W���󂯂�����
            PlayerEquipmentManager.Instance.PlayerStatus.TakeDamage(collision.gameObject.GetComponent<StandEnemyAttack>().AttackPower);
        }
        if (collision.gameObject.layer == THORN_LAYER_NUBER)
        {
            // �_���[�W���󂯂�����
            PlayerEquipmentManager.Instance.PlayerStatus.TakeDamage(_thornDamage);
        }
        if (collision.gameObject.CompareTag("ClearFlag"))
        {
            SceneGameManager.Instance.OnGameClear();
        }
        if (collision.gameObject.CompareTag("Death"))
        {
            SceneGameManager.Instance.OnGameOver();
        }
    }
    private void HandleTriggerEnter(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("StandEnemy"))
        {
            PlayerEquipmentManager.Instance.PlayerStatus.TakeDamage(_standEnemy.GetComponent<StandEnemyAttack>().AttackPower);
        }
    }
   
    

}
