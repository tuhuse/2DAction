using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    void Start()
    {
  
        PlayerCollisionDetector collisionDetector = GetComponent<PlayerCollisionDetector>();
        if (collisionDetector != null)
        {
            collisionDetector.OnPlayerCollisionEnter += HandleCollisionEnter;
        }
    }

    private void HandleCollisionEnter(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SoldierEnemy"))
        {
            // É_ÉÅÅ[ÉWÇéÛÇØÇΩèàóù
            EquipmentInventory.Instance._playerStatus.TakeDamage(collision.gameObject.GetComponent<SoldierEnemyAttack>().AttackPower);
        }

        if (collision.gameObject.CompareTag("ClearFlag"))
        {
            SceneGameManager.Instance.OnGameClear();
        }
    }

    

}
