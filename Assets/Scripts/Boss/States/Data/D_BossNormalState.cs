using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newBossNormalStateData", menuName = "Data/BossStateData/BossNormalState")]
public class D_BossNormalState : ScriptableObject
{
    public string animBoolName = "normal";

    public float timeBetweenAttack = 2;
    public float timeBetweenSpecial = 8;
    public float meleeDistance = 2;
}
