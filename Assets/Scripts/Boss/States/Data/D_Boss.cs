using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newBossData", menuName = "Data/BossData/BaseData")]
public class D_Boss : ScriptableObject {
    public float maxHealth;
    public float detectDistance = 30;

    public float hpRateToAngry = 0.5f;

    public LayerMask whatIsPlayer;
}
