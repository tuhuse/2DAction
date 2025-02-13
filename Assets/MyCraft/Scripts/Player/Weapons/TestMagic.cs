using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMagic : MonoBehaviour
{
    protected WeaponEquipmentData _weaponData = default;
    
   [SerializeField] private GameObject _waaponPrefab;
    private GameObject _weapon = default;
    protected GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_weapon == null)
            {
                _weapon = Instantiate(_waaponPrefab,this.transform.position, Quaternion.identity);
            }
          
        }
        if (_weapon != null)
        {
            _weapon.transform.position += Vector3.right * 50 * Time.deltaTime;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (_weapon)
        {
            if (collision.gameObject.CompareTag("Floor"))
            {
                Destroy(_weapon);
            }
        }
    }
}
