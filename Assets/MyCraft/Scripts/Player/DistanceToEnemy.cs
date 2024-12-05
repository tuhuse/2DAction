using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceToEnemy : MonoBehaviour
{
    private Transform[] _enemy;
    private float _distance = 10f;
    private const float DISTANCE_ENEMY = 10f;
    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void DistanceeMasurement()
    {
        float enemyDistance = Vector2.Distance(this.transform.position, _enemy[0].position);
        if (enemyDistance < DISTANCE_ENEMY)
        {
           
        }
    }
}
