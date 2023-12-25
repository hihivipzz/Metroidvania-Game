using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerProperty playerProperty;
    public PlayerInputActions playerInputActions;
    public Rigidbody2D rigidBody;
    public BoxCollider2D boxCollider2D;
    public PlayerAnimator playerAnimator;
    public GameObject groundCheckPoint;
    public LayerMask groundLayer;
    public bool _isFacingRight;

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
        playerInputActions.Player.Surfing.performed += OnSurfingPerformed;
        playerInputActions.Player.Surfing.canceled += OnSurfingCanceled;
    }

    void Start()
    {
        rigidBody.freezeRotation = true;
    }

    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(playerProperty.moveVector.x * playerProperty.moveSpeed, rigidBody.velocity.y);
        CheckGround();
        playerProperty.isJumping = !playerProperty.isGrounded;

        if (!playerProperty.isJumping && playerProperty.isWalking)
        {
            playerProperty.moveSpeed = playerProperty.walkSpeed;
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
        if (playerProperty.isGrounded)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, playerProperty.jumpPower);
            playerAnimator.JumpAnimation(true);
            playerProperty.isJumping = true;
            playerProperty.isDoubleJumping = true;
        }

        if (!playerProperty.isGrounded && playerProperty.isJumping && playerProperty.isDoubleJumping)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, playerProperty.jumpPower);
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

    public void OnSurfingPerformed(InputAction.CallbackContext context)
    {
        Vector2 newPosition = _isFacingRight ? new Vector2(transform.position.x + 10f, transform.position.y) : new Vector2(transform.position.x - 10f, transform.position.y);
        rigidBody.MovePosition(newPosition);
        playerAnimator.SurfingAnimation(true);
    }

    public void OnSurfingCanceled(InputAction.CallbackContext context)
    {
        playerAnimator.SurfingAnimation(false);
    }

    public void Flip(bool isFacingRight)
    {
        _isFacingRight = isFacingRight;
        transform.localScale = new Vector3(isFacingRight ? 1f : -1f, 1f, 1f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheckPoint.transform.position, 0.1f);
    }

    public void CheckGround()
    {
        playerProperty.isGrounded = Physics2D.OverlapCircle(groundCheckPoint.transform.position, 0.1f, groundLayer);
    }
}
