using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newBossLongRangeAttackStateData", menuName = "Data/BossStateData/BossLongRangeAttackState")]
public class D_BossLongRangeAttackState : ScriptableObject
{
    public string animBoolName = "rangeAttack";
    public GameObject projectile;
    
    public float projectTileSpeed=20;
    public float projectTileDame = 4;
}
