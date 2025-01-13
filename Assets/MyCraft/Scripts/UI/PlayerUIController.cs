using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
   [SerializeField] private PlayerHealthBar _healthBar;
    private PlayerStatus _status;
    // Start is called before the first frame update
    void Start()
    {
        _status= EquipmentInventory.Instance._playerStatus;
        _status.InitializeHealthBar(_healthBar);
    }
}
