using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newRangeAttackStateData", menuName = "Data/StateData/RangeAttackState")]
public class D_RangeAttackState : ScriptableObject
{
    public string animBoolName = "isRangeAttacking";

    public GameObject projectile;
    public float projectileDamage = 10f;
    public float projectileSpeed = 12f;
    public float projectileTravelDistance = 20f;
}
