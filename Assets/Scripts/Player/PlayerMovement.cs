using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerProperty playerProperty;
    public PlayerInputActions playerInputActions;
    public Rigidbody2D rigidBody = null;
    public LayerMask whatIsGround;
    public BoxCollider2D boxCollider2D;
    public PlayerAnimator playerAnimator;
    private Vector2 vectorGravity;

    void Awake()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
        playerProperty = GetComponent<PlayerProperty>();
        playerInputActions = new PlayerInputActions();
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    private void OnEnable()
    {
        playerInputActions.Enable();
        playerInputActions.Player.Move.performed += OnRunPerformed;
        playerInputActions.Player.Move.canceled += OnRunCanceled;
        playerInputActions.Player.Jump.performed += OnJumpPerformed;
        playerInputActions.Player.Jump.canceled += OnJumpCanceled;
        playerInputActions.Player.Walk.performed += OnWalkPerformed;
        playerInputActions.Player.Walk.canceled += OnWalkCanceled;
    }

    void Start()
    {
        vectorGravity = new Vector2(0, -Physics2D.gravity.y);
        rigidBody.freezeRotation = true;
    }

    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(playerProperty.moveVector.x * playerProperty.moveSpeed, rigidBody.velocity.y);
        playerProperty.isGrounded = Physics2D.OverlapCircle(rigidBody.position, playerProperty.checkRadius, whatIsGround);

        playerProperty.isJumping = !playerProperty.isGrounded;

        if (!playerProperty.isJumping && playerProperty.isWalking)
        {
            playerProperty.moveSpeed = playerProperty.walkSpeed;
        }

        if (rigidBody.velocity.y < 0)
        {
            rigidBody.velocity -= vectorGravity * playerProperty.fallMultiplier * Time.deltaTime;
        }

        playerAnimator.JumpAnimation(!playerProperty.isGrounded);
    }

    public void OnRunPerformed(InputAction.CallbackContext context)
    {
        playerProperty.moveVector = context.ReadValue<Vector2>();
        Flip(playerProperty.moveVector.x > 0f ? true : false);
        playerProperty.isRunning = true;
        playerProperty.moveSpeed = playerProperty.runSpeed;
        playerAnimator.RunAnimation(true);
    }

    public void OnRunCanceled(InputAction.CallbackContext context)
    {
        playerProperty.isRunning = false;
        playerAnimator.RunAnimation(false);
        playerProperty.moveVector = Vector2.zero;
    }

    public void OnJumpPerformed(InputAction.CallbackContext context)
    {
        playerProperty.isGrounded = Physics2D.OverlapCircle(rigidBody.position, playerProperty.checkRadius, whatIsGround);

        if (playerProperty.isGrounded)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, playerProperty.jumpPower);
            playerAnimator.JumpAnimation(true);
            playerProperty.isJumping = true;
            playerProperty.isDoubleJumping = true;
        }

        if (!playerProperty.isGrounded && playerProperty.isJumping && playerProperty.isDoubleJumping)
        {
            //rigidBody.velocity = new Vector2(rigidBody.velocity.x, playerProperty.jumpPower);
            rigidBody.velocity += vectorGravity * playerProperty.jumpMultiplier * Time.deltaTime;
            playerAnimator.JumpAnimation(true);
            playerProperty.isDoubleJumping = false;
        }
    }

    public void OnJumpCanceled(InputAction.CallbackContext context)
    {
        playerProperty.isJumping = false;
    }

    public void OnWalkPerformed(InputAction.CallbackContext context)
    {
        playerProperty.isWalking = true;
        if (playerProperty.isJumping)
        {
            return;
        }
        playerProperty.moveSpeed = playerProperty.walkSpeed;
    }

    public void OnWalkCanceled(InputAction.CallbackContext context)
    {
        playerProperty.moveSpeed = playerProperty.runSpeed;
        playerProperty.isWalking = false;
    }

    public void Flip(bool isFacingRight)
    {
        transform.localScale = new Vector3(isFacingRight ? 1f : -1f, 1f, 1f);
    }
}
