using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAwakeState : BossState
{
    D_BossAwakeState stateData;
    protected bool isFinish ;
    public BossAwakeState(FiniteStateMachine stateMachine,  Boss boss,D_BossAwakeState stateData) : base(stateMachine, stateData.animBoolName, boss)
    {
        this.stateData = stateData;
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        isFinish= false;
        boss.atsm.awakeState = this;
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public virtual void FinishAwake()
    {
        isFinish= true;
    }
}
