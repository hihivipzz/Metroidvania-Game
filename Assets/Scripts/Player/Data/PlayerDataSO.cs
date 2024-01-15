using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player/PlayerData" )]
public class PlayerDataSO : ScriptableObject
{
    public float maxHealth;
    public int maxLife = 3;

    public float gravityScale = 8.0f;

    public float groundCheckRadius = 0.3f;
    public float wallCheckDistance = 0.1f;


    public float runSpeed = 10.0f;
    public float jumpPower = 50.0f;
    public int airJumps = 1;
    public float jumpCoyoteTime = 0.15f;
    public float jumpBufferTime = 0.1f;
    public float fallGravityMultiplier = 1.9f;
    public float jumpCutGravityMult = 0f;
    public float jumpHangTimeThrehold = 0.1f;
    public float jumpHangTimeGravityMult = 0.5f;
    public float maxFallSpeed = 45.0f;
    

    public float dashTime = 0.2f;
    public float dashSpeed = 30.0f;
    public float distanceBetweenDashImage = 0.5f;
    public float dashCooldown = 1.0f;

    public float knockbackDuration = 0.2f;
    public float knockbackSpeedX = 10f;
    public float knockbackSpeedY = 10f;

    public float guardBufferTime = 0.2f;
    public float guardDameDecrease = 0.5f;
    public float guardCounterDameRadius = 1.5f;
    public float guardCouterDame = 2;
    public LayerMask whatIsDamageable;

    public float wallSlideSpeed = 20f;
    public float wallJumpBuffertime =0.2f;
    public float wallJumpForceX = 20f;
    public float wallJumpForceY = 20f;


    public LayerMask whatIsItem;
    public LayerMask whatIsNpc;
    public float itemDistance=0.5f;
    public float nPCDistance = 0.5f;

}
