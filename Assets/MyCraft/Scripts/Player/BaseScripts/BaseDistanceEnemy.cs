using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDistanceEnemy : MonoBehaviour
{
    protected Transform[] _enemies;          // 敵のTransform配列
    protected Transform _nearestEnemy;       // 一番近い敵のTransform
    protected const float DETECTION_RADIUS = 10f;  // 敵を検出する最大距離
    public bool CanAttack { get; set; }
   

    void Update()
    {
        FindNearestEnemy();
    }

    /// <summary>
    /// 最も近い敵を見つける処理
    /// </summary>
    protected abstract void FindNearestEnemy();
}
