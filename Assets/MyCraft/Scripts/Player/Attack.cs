using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour,IAttack
{
   
    public BoxCollider2D _playerBoxCollider = default;
    void Start()
    {
     
        _playerBoxCollider = GetComponent<BoxCollider2D>();
        _playerBoxCollider.enabled = false;

    }

    public virtual void PlayerAction()
    {
        _playerBoxCollider.enabled = true;
    }
}
