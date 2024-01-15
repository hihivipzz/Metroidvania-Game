using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport1To2 : Transport {
    public BossMechaGolem boss;

    public override void TransportToPosition(Player player)
    {
        if (boss.isDead)
        {
            base.TransportToPosition(player);
            player.SetReviePos(player.transform.position);
        }
    }
}
