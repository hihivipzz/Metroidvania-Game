using UnityEngine;

public class PlayerProperty : MonoBehaviour
{
    public float runSpeed = 10f;
    public float walkSpeed = 3f;
    public float moveSpeed = 10f;
    public Vector2 moveVector;
    public float jumpPower = 10f;
    public bool isGrounded = false;
    public float checkRadius = 0.5f;
    public LayerMask whatIsGround;
    public bool isWalking = false;
    public bool isRunning = false;
    public bool isJumping = false;
    public bool isDoubleJumping = false;
    public float fallMultiplier = 3f;
    public float jumpMultiplier = 3f;
    public float maxBlood = 100f;
    public float minBlood = 100f;
}
