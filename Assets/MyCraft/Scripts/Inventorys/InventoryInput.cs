using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInput : BaseUpdatable
{
    private EquipmentSwitcher _equipmentSwitcher;
    private int _serectNumber = 0;
    private const float WAIT_TIME = 2f;
    public bool _canUse { get; set; } = true;
    // Start is called before the first frame update
    void Start()
    {
        _equipmentSwitcher = GameObject.FindFirstObjectByType<EquipmentSwitcher>();
    }
    public override void OnUpdate()
    {
        for (int addnumber = 0; addnumber < 5; addnumber++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1+addnumber))
            {
                _serectNumber=addnumber;
            }
        }
        if (_canUse)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _equipmentSwitcher.EquipBodyEquipment(_serectNumber);
                StartCoroutine(CoolTIme(WAIT_TIME));
            }
        }
           
    }
   private IEnumerator CoolTIme(float waitTime)
    {
        _canUse = false;
        yield return new WaitForSeconds(waitTime);
        _canUse = true;
    }
    
    
}
