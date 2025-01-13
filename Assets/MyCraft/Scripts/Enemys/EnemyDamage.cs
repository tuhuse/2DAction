using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private EnemyStatus _enemyStatus;
    private GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _enemyStatus = GetComponent<EnemyStatus>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sord"))
        {
            _enemyStatus.TakeDamage(_player.GetComponent<SordWeapon>().AttackPower);
        }
    }
}
