using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy_DeadState : DeadState {
    MeleeEnemy mEnemy;

    public MeleeEnemy_DeadState(FiniteStateMachine stateMachine, Enemy enemy, D_DeadState stateData, MeleeEnemy mEnemy) : base(stateMachine, enemy, stateData)
    {
        this.mEnemy = mEnemy;
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

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
