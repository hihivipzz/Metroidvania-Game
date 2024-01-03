using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState : State
{
    protected Boss boss;

    public BossState(FiniteStateMachine stateMachine, string animBoolName,Boss boss) : base(stateMachine, animBoolName)
    {
        this.boss = boss;
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        boss.anim.SetBool(animBoolName, true);
        base.Enter();
    }

    public override void Exit()
    {
        boss.anim.SetBool(animBoolName,false);
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
