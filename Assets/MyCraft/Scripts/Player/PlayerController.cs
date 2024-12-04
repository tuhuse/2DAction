using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IPlayerAction _walk;
    private IPlayerAction _jump;

    private void Start()
    {
        // ファクトリを利用して動作クラスを生成
        _walk = PlayerActionFactory.CreateAction<Walk>("WalkAction");
       
    }

    public void PerformWalk()
    {
        _walk.PlayerAction();
    }

   
}
