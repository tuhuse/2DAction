using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerController,IAttack
{
    
    private BoxCollider2D _playerBoxCollider = default;

    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    private void Start()
    {
     
        _playerBoxCollider = GetComponent<BoxCollider2D>();
      
        _playerBoxCollider.enabled = false;

    }
    private void Update()
    {
      
    }
}
