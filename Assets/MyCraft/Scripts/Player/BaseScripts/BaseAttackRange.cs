using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAttackRange : MonoBehaviour
{
    protected Transform[] _enemies;          // �G��Transform�z��
    protected Transform _nearestEnemy;       // ��ԋ߂��G��Transform
    protected const float DETECTION_RADIUS = 10f;  // �G�����o����ő勗��
    public bool CanAttack { get; set; }
   

    void Update()
    {
        FindNearestEnemy();
    }

    /// <summary>
    /// �ł��߂��G�������鏈��
    /// </summary>
    protected abstract void FindNearestEnemy();
}
