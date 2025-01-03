using UnityEngine;

public class SoldierEnemy : BaseEnemy
{
    private void Start()
    {
        // 移動とジャンプの機能を設定
        SetMovement(gameObject.GetComponent<SoldierEnemyMove>());

        // 近接攻撃を設定
        SetAttack(gameObject.GetComponent<SoldierEnemyAttack>());
    }

    private void Update()
    {
        Move(); // 前進
        Attack();   // 攻撃
    }
}