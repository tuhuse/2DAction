using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private EnemyStatus _enemyStatus;
    private GameObject _player;
    private Rigidbody2D _rb;
    [TagSelector, SerializeField] private string _playerTag;
    [TagSelector, SerializeField] private string _sordTag;
    [SerializeField] private float knockbackForce = 20f; // �m�b�N�o�b�N�̋����𒲐�

    void Start()
    {
        _enemyStatus = GetComponent<EnemyStatus>();
        _player = GameObject.FindGameObjectWithTag(_playerTag);
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_sordTag))
        {
            if (this.gameObject.CompareTag("StandEnemy"))
            {
                _enemyStatus.TakeDamage(_player.GetComponent<SordWeapon>().AttackPower);

            }
            else
            {
                _enemyStatus.TakeDamage(_player.GetComponent<SordWeapon>().AttackPower);

                // �m�b�N�o�b�N�̕������v�Z�i�G �� �v���C���[�̋t�����j
                Vector2 knockbackDirection = (transform.position - _player.transform.position).normalized;

                // Rigidbody2D �ɗ͂�������
                _rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            }
          
        }
    }
}
