using System;
using System.Collections;
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

    [Header("Camera Stuff")]
    [SerializeField] private GameObject _cameraFollowGO;

    private CameraFollowObject _cameraFollowObject;
    private float _fallSpeedYDampingChangeThreshold;

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
        playerInputActions.Player.Dashing.performed += OnSurfingPerformed;
        playerInputActions.Player.JumpHigher.performed += OnJumpHigherPerformed;
    }

    void Start()
    {
        rigidBody.freezeRotation = true;

        _cameraFollowObject = _cameraFollowGO.GetComponent<CameraFollowObject>();
        _fallSpeedYDampingChangeThreshold = CameraManager.instance._fallSpeedDampingChangeThreshold;
    }


    private void Update()
    {
        if (playerProperty.isDead) return;

        if (rigidBody.velocity.y < _fallSpeedYDampingChangeThreshold && !CameraManager.instance.IsLerpingYDamping && !CameraManager.instance.LerpedFromPlayerFalling)
        {
            CameraManager.instance.LerpYDamping(true);
        }

        if (rigidBody.velocity.y >= 0f && !CameraManager.instance.IsLerpingYDamping && CameraManager.instance.LerpedFromPlayerFalling)
        {
            CameraManager.instance.LerpedFromPlayerFalling = false;

            CameraManager.instance.LerpYDamping(false);
        }
    }


    void FixedUpdate()
    {
        if (playerProperty.isDead) return;

        rigidBody.velocity = new Vector2(playerProperty.moveVector.x * playerProperty.moveSpeed, rigidBody.velocity.y);
        CheckGround();
        playerProperty.isJumping = !playerProperty.isGrounded;

        if (!playerProperty.isJumping && playerProperty.isWalking)
        {
            playerProperty.moveSpeed = playerProperty.walkSpeed;
        }

        playerAnimator.JumpAnimation(!playerProperty.isGrounded);

        if (playerProperty.moveVector.x > 0 || playerProperty.moveVector.x < 0)
        {
            TurnCheck();
        }
    }

    public void OnJumpHigherPerformed(InputAction.CallbackContext context)
    {
        if (playerProperty.isDead) return;

        if (!playerProperty.isGrounded && playerProperty.isJumping && playerProperty.isJumpHigher)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, playerProperty.jumpPower);
            playerProperty.isJumpHigher = false;
        }
    }

    public void OnRunPerformed(InputAction.CallbackContext context)
    {
        if (playerProperty.isDead) return;

        playerProperty.moveVector = context.ReadValue<Vector2>();
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
        if (playerProperty.isDead) return;

        if (playerProperty.isGrounded)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, playerProperty.jumpPower);
            playerAnimator.JumpAnimation(true);
            playerProperty.isJumping = true;
            playerProperty.isDoubleJumping = true;
            playerProperty.isJumpHigher = true;
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
        if (playerProperty.isDead) return;

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
        if (playerProperty.isDead) return;

        float raycastDistance = 10f;
        Vector2 raycastOrigin = _isFacingRight ? transform.position : new Vector2(transform.position.x - raycastDistance, transform.position.y);
        Vector2 newPosition = _isFacingRight ? new Vector2(transform.position.x + 10f, transform.position.y) : new Vector2(transform.position.x - 10f, transform.position.y);

        RaycastHit2D[] hits = Physics2D.RaycastAll(raycastOrigin, Vector2.right * (_isFacingRight ? 1 : -1), raycastDistance);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                float offset = 0.1f;
                float newXPosition = hit.point.x - (_isFacingRight ? offset : -offset);

                newPosition = new Vector2(newXPosition, transform.position.y);
            }
        }

        rigidBody.MovePosition(newPosition);
        playerAnimator.SurfingAnimation(true);
        StartCoroutine(OnSurfingCanceled(0.5f));
    }

    private IEnumerator OnSurfingCanceled(float delay)
    {
        yield return new WaitForSeconds(delay);
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

    private void TurnCheck()
    {
        if (_isFacingRight && playerProperty.moveVector.x < 0f)
        {
            Turn();
        }
        else if (!_isFacingRight && playerProperty.moveVector.x > 0f)
        {
            Turn();
        }
    }

    private void Turn()
    {
        if (_isFacingRight)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            _isFacingRight = !_isFacingRight;

            // turn the camera follow object
            _cameraFollowObject.CallTurn();
        }
        else
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            _isFacingRight = !_isFacingRight;

            // turn the camera follow object
            _cameraFollowObject.CallTurn();
        }
    }

}
