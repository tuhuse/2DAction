using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceToEnemy : MonoBehaviour
{
    private Transform[] _enemies;          // “G‚ÌTransform”z—ñ
    private Transform _nearestEnemy;       // ˆê”Ô‹ß‚¢“G‚ÌTransform
    private const float DETECTION_RADIUS = 10f;  // “G‚ğŒŸo‚·‚éÅ‘å‹——£
    public bool CanAttack { get; private set; }
    void Start()
    {
        // ƒV[ƒ““à‚Ì‚·‚×‚Ä‚Ì“G‚ğ’T‚µATransform‚ğæ“¾‚·‚é
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
    /// Å‚à‹ß‚¢“G‚ğŒ©‚Â‚¯‚éˆ—
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

        // ‹ß‚¢“G‚ªŒ©‚Â‚©‚Á‚½ê‡‚Ìˆ—
        if (_nearestEnemy != null)
        {
            Debug.Log($"‹ß‚¢“G: {_nearestEnemy.name} ‚Æ‚Ì‹——£: {minDistance}");
            // —á: “G‚ÉŒü‚©‚Á‚Ä–îˆó‚ğŒü‚¯‚éˆ—‚È‚Ç
            Debug.DrawLine(this.transform.position, _nearestEnemy.position, Color.red);
            CanAttack = true;

        }
        else
        {
            CanAttack = false;
        }
    }
}
