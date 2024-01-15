using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeadState : BossState {
    public static event EventHandler OnBossDeadState;
    D_BossDeadState stateData;

    public BossDeadState(FiniteStateMachine stateMachine,  Boss boss, D_BossDeadState stateData) : base(stateMachine, stateData.animBoolName, boss)
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
        OnBossDeadState?.Invoke(this, EventArgs.Empty);
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

    public virtual void SpawnItem()
    {

    }
}
