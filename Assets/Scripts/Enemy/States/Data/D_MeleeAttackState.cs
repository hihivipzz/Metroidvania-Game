using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newMeleeAttackStateData", menuName = "Data/StateData/MeleeAttackState")]
public class D_MeleeAttackState : ScriptableObject
{
    public string animBoolName = "isAttacking";

    public float attackRadius = 0.5f;

    public float attackDamage = 10f;



    public LayerMask whatIsPlayer;

}
