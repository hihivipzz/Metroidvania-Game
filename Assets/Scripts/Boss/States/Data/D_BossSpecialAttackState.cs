using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newBossSpecialAttackStateData", menuName = "Data/BossStateData/BossSpecialAttackState")]
public class D_BossSpecialAttackState : ScriptableObject
{
    public string animBoolName = "specialAttack";
    public float dame=1;
    public float timeBeetweenDame =0.5f;
    public float speed = 5;

    public LayerMask whatIsPlayer;
}
