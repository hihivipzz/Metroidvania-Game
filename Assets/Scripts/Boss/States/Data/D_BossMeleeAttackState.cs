using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newBossMeleeAttackStateData", menuName = "Data/BossStateData/BossMeleeAttackState")]
public class D_BossMeleeAttackState : ScriptableObject {
    public string animBoolName = "meleeAttack";

    public float attackDame = 5;
    public float attackRadius = 2;

    public LayerMask whatIsPlayer;
}
