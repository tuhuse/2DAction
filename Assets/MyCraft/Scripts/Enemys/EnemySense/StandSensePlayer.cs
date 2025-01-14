using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandSensePlayer : BaseSensePlayer
{/*public bool IsAttack { get; private set; }*/
   
    public override void FindPlayer()
    {
        float DistanceToPlayer = Mathf.Abs(_player.position.x - this.transform.position.x);

        // �v���C���[����苗���ȏ㗣��Ă���ꍇ�݈̂ړ�
        if (DistanceToPlayer < MAX_DISTANCE_PLAYER)
        {
            // �v���C���[�̕����𔻒�
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
