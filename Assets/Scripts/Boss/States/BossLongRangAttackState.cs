using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLongRangAttackState : BossAttackState {
    protected D_BossLongRangeAttackState stateData;

    public BossLongRangAttackState(FiniteStateMachine stateMachine,  Boss boss, D_BossLongRangeAttackState stateData,Transform attackPosition) : base(stateMachine, stateData.animBoolName, boss, attackPosition)
    {
        this.stateData = stateData;
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}
