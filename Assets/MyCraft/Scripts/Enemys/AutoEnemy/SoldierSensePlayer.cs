using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSensePlayer :BaseSensePlayer
{
    public override void FindPlayer()
    {
        float DistanceToPlayer = Mathf.Abs(_player.position.x - this.transform.position.x);

        // プレイヤーが一定距離以上離れている場合のみ移動
        if (DistanceToPlayer > MAX_DISTANCE_PLAYER)
        {
            // プレイヤーの方向を判定
            if (_player.position.x > this.transform.position.x)
            {
                IsRightFindPlayer = true;
                IsLeftFindPlayer = false;
            }
            else
            {
                IsRightFindPlayer = false;
                IsLeftFindPlayer = true;
            }
        }


    }

}
