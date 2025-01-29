using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInput : BaseUpdatable
{
    private EquipmentSwitcher _equipmentSwitcher;
    private int _serectNumber = 0;
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
        if (Input.GetMouseButtonDown(0))
        {
            _equipmentSwitcher.EquipBodyEquipment(_serectNumber);
        }
    }
   
}
