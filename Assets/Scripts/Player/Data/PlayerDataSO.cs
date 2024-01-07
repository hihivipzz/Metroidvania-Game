using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player/PlayerData" )]
public class PlayerDataSO : ScriptableObject
{
    public float maxHealth;

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

    public float knockbackDuration = 0.5f;



}
