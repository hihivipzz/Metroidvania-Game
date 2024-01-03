using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : State
{
    protected Enemy enemy;
    public EnemyState(FiniteStateMachine stateMachine, Enemy enemy, string animBoolName) : base(stateMachine, animBoolName)
    {
        this.enemy = enemy;
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        enemy.anim.SetBool(animBoolName, true);
        base.Enter();
    }

    public override void Exit()
    {
        enemy.anim.SetBool(animBoolName, false);
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
