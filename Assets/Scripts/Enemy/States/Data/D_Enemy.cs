using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newEnemyData", menuName = "Data/EnemyData/BaseData")]
public class D_Enemy : ScriptableObject {
    public float maxHealth = 30f;

    public float damageHopSpeed = 3f;
    public float knockbackSpeedX = 0.1f;
    public float knockbackSpeedY = 0.1f;
    public float knockbackDuration = 0.1f;

    public float wallCheckDistance = 0.2f;
    public float ledgeCheckDistance = 0.4f;
    public float groundCheckRadius = 0.3f;

    public float maxAgroDistance = 4f;
    public float minAgroDistance = 3f;

    public float closeRangeActionDistance = 1f; 

    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;

    public int minGold = 7;
    public int maxGold = 12;

}
