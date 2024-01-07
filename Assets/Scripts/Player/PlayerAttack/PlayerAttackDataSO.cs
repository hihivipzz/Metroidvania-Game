using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player/PlayerAttackData", order = 1)]

public class PlayerAttackDataSO : ScriptableObject
{
    public LayerMask whatIsDamageable;
    public float attackRadius;
    public float attackDamage;

}
