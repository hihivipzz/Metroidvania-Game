using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private float moveSpeed = 3f;
    private PlayerInputActions playerInputActions;
    private Rigidbody2D rigidBody = null;
    private Animator animator = null;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        playerInputActions.Enable();
        playerInputActions.Player.Move.performed += OnMovementPerformed;
        playerInputActions.Player.Move.canceled += OnMovementCanceled;
    }

    private void OnDisable()
    {
        playerInputActions.Disable();
        playerInputActions.Player.Move.performed -= OnMovementPerformed;
        playerInputActions.Player.Move.canceled -= OnMovementCanceled;
    }

    private void Start()
    {
        Flip(true);
    }

    private void OnMovementPerformed(InputAction.CallbackContext context)
    {
        animator.SetBool("isRun", true);
        var moveVector = context.ReadValue<Vector2>();
        moveVector.y = 0f; // only move left or right

        if (moveVector.x > 0f)
        {
            Flip(true);
        }
        else
        {
            Flip(false);
        }

        rigidBody.velocity = moveVector * moveSpeed;
    }

    private void OnMovementCanceled(InputAction.CallbackContext context)
    {
        animator.SetBool("isRun", false);
        rigidBody.velocity = Vector2.zero * moveSpeed;
    }

    private void Flip(bool isFacingRight)
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Sign(isFacingRight ? 1f : -1f);

        rigidBody.transform.localScale = scale;
    }
}
