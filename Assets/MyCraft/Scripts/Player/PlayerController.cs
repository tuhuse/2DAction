using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IPlayerAction _walk;
    private IPlayerAction _jump;

    private void Start()
    {
     
       
    }

    public void PerformWalk()
    {
        _walk.PlayerAction();
    }

   
}
