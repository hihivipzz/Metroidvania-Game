using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationToStateMachine : MonoBehaviour
{
    public BossAwakeState awakeState;
    public BossAttackState attackState;

    private void FinishAwake()
    {
        awakeState.FinishAwake();
    }

    private void TriggerAttack()
    {
        attackState.TriggerAttack();
    }

    private void FinishAttack()
    {
        attackState.FinishAttack();
    }
}
