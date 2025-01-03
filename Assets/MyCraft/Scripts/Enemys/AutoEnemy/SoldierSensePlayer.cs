using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSensePlayer :BaseSensePlayer
{
    public override void FindPlayer()
    {
        float DistanceToPlayer = Mathf.Abs(_player.position.x - this.transform.position.x);

        // �v���C���[����苗���ȏ㗣��Ă���ꍇ�݈̂ړ�
        if (DistanceToPlayer > MAX_DISTANCE_PLAYER)
        {
            // �v���C���[�̕����𔻒�
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
