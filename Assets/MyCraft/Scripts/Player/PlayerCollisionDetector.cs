using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{
   
    public delegate void CollisionStayEventHandler(Collision2D collision);
    public delegate void TriggerEventHandler(Collider2D collision);
    public delegate void CollisionEnterEventHandler(Collision2D collision);
    public event CollisionStayEventHandler OnPlayerCollisionStay;
    public event TriggerEventHandler OnPlayerTriggerEnter;
    public event CollisionEnterEventHandler OnPlayerCollisionEnter;
  

    private void OnCollisionStay2D(Collision2D collision)
    {
       
            OnPlayerCollisionStay.Invoke(collision); // 衝突情報をイベントとして通知
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnPlayerCollisionEnter.Invoke(collision);   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnPlayerTriggerEnter.Invoke(collision);
    }

}
