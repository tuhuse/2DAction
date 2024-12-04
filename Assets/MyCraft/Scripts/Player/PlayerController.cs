using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IPlayerAction _walk;
    private IPlayerAction _jump;

    private void Start()
    {
        // �t�@�N�g���𗘗p���ē���N���X�𐶐�
        _walk = PlayerActionFactory.CreateAction<Walk>("WalkAction");
       
    }

    public void PerformWalk()
    {
        _walk.PlayerAction();
    }

   
}
