using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandSensePlayer : BaseSensePlayer
{/*public bool IsAttack { get; private set; }*/
   
    public override void FindPlayer()
    {
        float DistanceToPlayer = Mathf.Abs(_player.position.x - this.transform.position.x);

        // プレイヤーが一定距離以上離れている場合のみ移動
        if (DistanceToPlayer < MAX_DISTANCE_PLAYER)
        {
            // プレイヤーの方向を判定
            if (_player.position.x < this.transform.position.x)
            {
                IsAttack = true;
            }

        }
        else
        {
            IsAttack = false;
        }
    }
}
