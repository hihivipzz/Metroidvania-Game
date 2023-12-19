using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 3f;
    private PlayerInputActions playerInputActions;
    private Rigidbody2D rigidBody = null;
    private Vector2 moveVector;
    private float jumpHeight = 5f;
    private bool isGrounded = false;
    private float checkRadius = 0.5f;
    public LayerMask whatIsGround;
    public BoxCollider2D boxCollider2D;
    public PlayerAnimator playerAnimator;
    public bool isWalking = false;
    public bool isRunning = false;
    public bool isJumping = false;
    public bool isDoubleJumping = false;

    void Awake()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
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
        rigidBody.freezeRotation = true;
    }

    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(moveVector.x * moveSpeed, rigidBody.velocity.y);
        isGrounded = Physics2D.OverlapCircle(rigidBody.position, checkRadius, whatIsGround);

        isJumping = !isGrounded;

        if (!isJumping && isWalking)
        {
            moveSpeed = 1f;
        }

        playerAnimator.JumpAnimation(!isGrounded);
    }

    public void OnRunPerformed(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
        Flip(moveVector.x > 0f ? true : false);
        isRunning = true;
        moveSpeed = 3f;
        playerAnimator.RunAnimation(true);
    }

    public void OnRunCanceled(InputAction.CallbackContext context)
    {
        isRunning = false;
        playerAnimator.RunAnimation(false);
        moveVector = Vector2.zero;
    }

    public void OnJumpPerformed(InputAction.CallbackContext context)
    {
        isGrounded = Physics2D.OverlapCircle(rigidBody.position, checkRadius, whatIsGround);

        if (isGrounded)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpHeight);
            playerAnimator.JumpAnimation(true);
            isJumping = true;
            isDoubleJumping = true;
        }

        if (!isGrounded && isJumping && isDoubleJumping)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpHeight);
            playerAnimator.JumpAnimation(true);
            isDoubleJumping = false;
        }
    }

    public void OnJumpCanceled(InputAction.CallbackContext context)
    {
        isJumping = false;
    }

    public void OnWalkPerformed(InputAction.CallbackContext context)
    {
        isWalking = true;
        if (isJumping)
        {
            return;
        }
        moveSpeed = 1f;
    }

    public void OnWalkCanceled(InputAction.CallbackContext context)
    {
        moveSpeed = 3f;
        isWalking = false;
    }

    public void Flip(bool isFacingRight)
    {
        transform.localScale = new Vector3(isFacingRight ? 1f : -1f, 1f, 1f);
    }
}
