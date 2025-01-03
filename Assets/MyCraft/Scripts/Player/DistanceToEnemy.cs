using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceToEnemy : MonoBehaviour
{
    private Transform[] _enemies;          // 敵のTransform配列
    private Transform _nearestEnemy;       // 一番近い敵のTransform
    private const float DETECTION_RADIUS = 10f;  // 敵を検出する最大距離
    public bool CanAttack { get; private set; }
    void Start()
    {
        // シーン内のすべての敵を探し、Transformを取得する
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        _enemies = new Transform[enemyObjects.Length];

        for (int i = 0; i < enemyObjects.Length; i++)
        {
            _enemies[i] = enemyObjects[i].transform;
        }
    }

    void Update()
    {
        FindNearestEnemy();
    }

    /// <summary>
    /// 最も近い敵を見つける処理
    /// </summary>
    private void FindNearestEnemy()
    {
        float minDistance = DETECTION_RADIUS;
        _nearestEnemy = null;

        foreach (Transform enemy in _enemies)
        {
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
