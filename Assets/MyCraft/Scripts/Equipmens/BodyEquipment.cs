using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 生成されている装備
/// </summary>
public class BodyEquipment : MonoBehaviour
{
    [SerializeField] private BodyEquipmentData _equipmentdata;
     private InventorySystem _inventorySystem;
    private Transform _player;
    private const float LOOK_DISTANCE = 5; 
    private bool _isLookEquipment = false;
    // Start is called before the first frame update
   private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _inventorySystem = GameObject.FindFirstObjectByType<InventorySystem>();
    }

    // Update is called once per frame
   private void Update()
    {
        SensePlayer();
    }
    private void SensePlayer()
    {
        float playerDistance = Vector2.Distance(_player.position, this.transform.position);
        if (playerDistance < LOOK_DISTANCE)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _inventorySystem.AddBodyEquipment(_equipmentdata);
                Destroy(gameObject);
            }
        }
    }
   
}
