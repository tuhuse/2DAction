using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SordAttackRange : BaseAttackRange
{
   

    void Start()
    {
        // 対象タグを配列で管理
        string[] targetTags = { "SoldierEnemy","StandEnemy"/*, "Boss", "Minion"*/ };
        List<Transform> enemiesList = new List<Transform>();

        foreach (string tag in targetTags)
        {
            GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject enemy in enemyObjects)
            {
                enemiesList.Add(enemy.transform);
            }
        }

        _enemies = enemiesList.ToArray();
    }

    protected override void FindNearestEnemy()
    {
        float minDistance = DETECTION_RADIUS;
        _nearestEnemy = null;

        foreach (Transform enemy in _enemies)
        {
            // enemy が null の場合はスキップ
            if (enemy == null)
            {
                continue;
            }

            float distance = Vector2.Distance(this.transform.position, enemy.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                _nearestEnemy = enemy;
            }
        }

        // 近い敵が見つかった場合の処理
        if (_nearestEnemy != null)
        {
            Debug.DrawLine(this.transform.position, _nearestEnemy.position, Color.red);
            CanAttack = true;
        }
        else
        {
            CanAttack = false;
        }
    }


}
