using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMechaGolem_BossDeadState : BossDeadState
{
    BossMechaGolem sBoss;
    public BossMechaGolem_BossDeadState(FiniteStateMachine stateMachine, BossMechaGolem sBoss, D_BossDeadState stateData) : base(stateMachine, sBoss, stateData)
    {
        this.sBoss = sBoss;
    }
}
