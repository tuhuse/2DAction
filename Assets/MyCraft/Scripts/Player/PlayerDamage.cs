using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    PlayerStatus _playerStatus = new PlayerStatus();
    void Start()
    {
        PlayerCollisionDetector collisionDetector =GetComponent<PlayerCollisionDetector>();
        if (collisionDetector != null)
        {
            collisionDetector.OnPlayerCollisionEnter += HandleCollisionEnter;
        }
    }
    private void HandleCollisionEnter(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SoldierEnemy"))
        {
            _playerStatus.TakeDamage(collision.gameObject.GetComponent<SoldierEnemyAttack>().AttackPower);
        }
           
    }
}
