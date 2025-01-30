using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
   [SerializeField] private PlayerHealthBar _healthBar;
    private PlayerController _playerController;
    private PlayerStatus _status;
    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.FindFirstObjectByType<PlayerController>();
        _status= _playerController.PlayerStatus;
        _status.InitializeHealthBar(_healthBar);
    }
}
