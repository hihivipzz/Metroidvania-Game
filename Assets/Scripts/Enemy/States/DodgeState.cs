using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeState : EnemyState {
    protected D_DodgeState stateData;

    protected bool performCloseRangeAction;
    protected bool isPlayerInMaxAgroRange;
    protected bool isGrounded;
    protected bool isDodgeOver;

    public DodgeState(FiniteStateMachine stateMachine, Enemy enemy,D_DodgeState stateData) : base(stateMachine, enemy, stateData.animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoCheck()
    {
        base.DoCheck();

        performCloseRangeAction= enemy.CheckPlayerInCloseRangeAction();
        isPlayerInMaxAgroRange= enemy.CheckPlayerInManAgroRange();
        isGrounded = enemy.CheckGround();

    }

    public override void Enter()
    {
        base.Enter();

        isDodgeOver= false;

        enemy.SetVelocity(stateData.dodgeSpeed, stateData.dodgeAngle, -enemy.facingDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        enemy.anim.SetFloat("yVelocity", enemy.rb.velocity.y);

        if(Time.time >= startTime+stateData.dodgeTime && isGrounded)
        {
            isDodgeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
