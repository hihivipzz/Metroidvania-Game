using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeEnemy_DeadState : DeadState
{
    private LongRangeEnemy lREnemy;

    public LongRangeEnemy_DeadState(FiniteStateMachine stateMachine, Enemy enemy, D_DeadState stateData, LongRangeEnemy lREnemy) : base(stateMachine, enemy, stateData)
    {
        this.lREnemy = lREnemy;
    }
}
