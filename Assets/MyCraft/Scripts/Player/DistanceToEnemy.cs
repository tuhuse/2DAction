using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceToEnemy : MonoBehaviour
{
    private Transform[] _enemies;          // �G��Transform�z��
    private Transform _nearestEnemy;       // ��ԋ߂��G��Transform
    private const float DETECTION_RADIUS = 10f;  // �G�����o����ő勗��
    public bool CanAttack { get; private set; }
    void Start()
    {
        // �V�[�����̂��ׂĂ̓G��T���ATransform���擾����
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
    /// �ł��߂��G�������鏈��
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

        // �߂��G�����������ꍇ�̏���
        if (_nearestEnemy != null)
        {
            Debug.Log($"�߂��G: {_nearestEnemy.name} �Ƃ̋���: {minDistance}");
            // ��: �G�Ɍ������Ė��������鏈���Ȃ�
            Debug.DrawLine(this.transform.position, _nearestEnemy.position, Color.red);
            CanAttack = true;

        }
        else
        {
            CanAttack = false;
        }
    }
}
