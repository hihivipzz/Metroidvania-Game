using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSleepState : BossState
{
    public static event EventHandler OnBossSleep;
    protected D_BossSleepState stateData;
    protected bool isPlayerDetected;

    public BossSleepState(FiniteStateMachine stateMachine,  Boss boss,D_BossSleepState stateData) : base(stateMachine, stateData.animBoolName, boss)
    {
        this.stateData = stateData;
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isPlayerDetected = boss.CheckPlayerInRange();
    }

    public override void Enter()
    {
        OnBossSleep?.Invoke(this, EventArgs.Empty);
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
}
