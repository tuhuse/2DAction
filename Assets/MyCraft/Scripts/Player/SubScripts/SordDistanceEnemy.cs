using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SordDistanceEnemy : BaseDistanceEnemy
{
   

    // Start is called before the first frame update
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
    protected override void FindNearestEnemy()
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

            Debug.DrawLine(this.transform.position, _nearestEnemy.position, Color.red);
            CanAttack = true;

        }
        else
        {
            CanAttack = false;
        }
    }


}
