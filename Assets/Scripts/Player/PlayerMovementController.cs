using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovementController : MonoBehaviour
{
    public event EventHandler OnDoubleJump;

    private Player player;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform frontWallCheck;
    [SerializeField] private Vector2 wallCheckSize = new Vector2(0.5f,1f);
    private PlayerDataSO data;
    

    public LayerMask whatIsGround;

    public bool isRunning { get; private set; }
    public bool isDashing { get; private set; }
    public bool isKnockback { get; private set; }
    public bool isWallSlide { get; private set; }
    public bool isWallJumping { get; private set; }


    private Vector3 moveDir;
    private bool canMove;
    private bool isFacingRight;
    private int facingDirection;
    private bool canFlip;
    


    public bool isGrounded {get; private set;}
    private bool canJump;
    private int bonusJumpLeft;
    private float lastGroundedTime;
    private float lastJumpTime;
    private bool isJumping;
    private bool isJumpFalling;
    private bool isJumpCut;
    public float lastPressedJumpTime;
    public float lastOnWallTime;
    public float lastOnWallLeft;
    public float lastOnwallRight;


    private bool isTouchingWall;
    private float lastImageXPos;
    private float lastDash = -100f;
    private float dashTimeLeft;
    private float knockbackStartTime;
    private Vector2 knockbackSpeed;
    private float wallJumpStartTime;
    private int lastWallJumpDir;


    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player= GetComponent<Player>();
        data = player.GetData();
        knockbackSpeed = new Vector2(data.knockbackSpeedX,data.knockbackSpeedY);

        SetGravityScale(data.gravityScale);

        isFacingRight = true;
        facingDirection = 1;
        bonusJumpLeft = data.airJumps;
        canMove = true;
        canFlip = true;
        isKnockback = false;
        isDashing = false;

        gameInput.OnJumpAction += GameInput_OnJumpAction;
        gameInput.OnJumpCancel += GameInput_OnJumpCancel;
        gameInput.onDashAction += GameInput_onDashAction;

    }

    private void GameInput_onDashAction(object sender, System.EventArgs e)
    {
        if (Time.time >= (lastDash + data.dashCooldown) && !isKnockback)
        {
            AttempToDash();
        }   
    }

    private void GameInput_OnJumpCancel(object sender, System.EventArgs e)
    {
        if((isJumping||isWallJumping) && rb.velocity.y > 0)
        {
            isJumpCut = true;
        }
        //CancelJump();
    }

    private void GameInput_OnJumpAction(object sender, System.EventArgs e)
    {
        lastPressedJumpTime = data.jumpBufferTime;
        //Jump();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isTouchingWall);
        CheckMovementDirection();
        CheckCanJump();
        JumpHandler();
        CheckKnockBack();
        CheckCanWallSlide();
    }

    private void FixedUpdate()
    {
        RunHandler();
        DashHandler();
        CheckSurrounding();
        WallSlideHandler();
    }

    public void KnockBack(float direction)
    {
        isKnockback = true;
        knockbackStartTime = Time.time;
        rb.velocity = new Vector2(knockbackSpeed.x * direction, knockbackSpeed.y);
    }

    private void CheckKnockBack()
    {
        if(Time.time >= knockbackStartTime + data.knockbackDuration)
        {
            isKnockback= false;
            rb.velocity =new Vector2 (0.0f,rb.velocity.y);
        }
    }

    public void SetGravityScale(float scale)
    {
        rb.gravityScale = scale;
    }

    private void CheckMovementDirection()
    {
        if(isFacingRight && moveDir.x < 0)
        {
            Flip();
        }else if(!isFacingRight&& moveDir.x > 0)
        {
            Flip();
        }
    }

    private void CheckCanJump()
    {
        if(isGrounded && rb.velocity.y <= 0)
        {
            bonusJumpLeft = data.airJumps;
        }
        
        if(lastGroundedTime > 0 && !isJumping && !isKnockback)
        {
            canJump = true;
        }else
        {
            canJump =  false;
        }
    }

    private void CheckCanWallSlide()
    {
        if (isTouchingWall && !isGrounded && rb.velocity.y < 0 && moveDir.x*facingDirection > 0)
        {
            isWallSlide = true;
        }
        else
        {
            isWallSlide = false;
        }
    }

    private void JumpHandler()
    {
        lastGroundedTime -= Time.deltaTime;
        lastOnWallTime -= Time.deltaTime;
        lastPressedJumpTime -= Time.deltaTime;
        lastOnwallRight -= Time.deltaTime;
        lastOnWallLeft -= Time.deltaTime;

        if(isJumping && rb.velocity.y < 0)
        {
            isJumping= false;
            isJumpFalling = true;
        }

        if(isWallJumping && Time.time > wallJumpStartTime + data.wallJumpBuffertime)
        {
            isWallJumping = false;
        }

        if(lastGroundedTime > 0 && !isJumping && !isWallJumping)
        {
            isJumpCut = false;
            isJumpFalling= false;
        }

        

        if (!isDashing)
        {
            if (canJump && lastPressedJumpTime > 0)
            {
                isJumping = true;
                isJumpCut = false;
                isJumpFalling = false;
                Jump();
            }
            if (lastGroundedTime < 0 && bonusJumpLeft > 0 && lastPressedJumpTime > 0 && !CanWallJump())
            {
                isJumping = true;
                isJumpCut = false;
                isJumpFalling = false;
                Jump();
                bonusJumpLeft--;
                OnDoubleJump?.Invoke(this, EventArgs.Empty);

            }else if(CanWallJump() && lastPressedJumpTime > 0)
            {
                isWallJumping = true;
                isJumping = false;
                isJumpCut = false;
                isJumpFalling = false;

                wallJumpStartTime = Time.time;
                
                WallJump();
            }

        }

        

        //Gravity
        if (isJumpCut)
        {
            SetGravityScale(data.gravityScale * data.jumpCutGravityMult);
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -data.maxFallSpeed));
        }
        else if ((isJumping||isWallJumping) && Mathf.Abs(rb.velocity.y)<data.jumpHangTimeThrehold)
        {
            SetGravityScale(data.gravityScale * data.jumpHangTimeGravityMult);
        }else if(rb.velocity.y < 0)
        {
            SetGravityScale(data.gravityScale * data.fallGravityMultiplier);
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -data.maxFallSpeed));
        }
        else
        {
            SetGravityScale(data.gravityScale);
        }

    }

    private void CheckSurrounding()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.transform.position, data.groundCheckRadius, whatIsGround);
        if (isGrounded)
        {
            lastGroundedTime = data.jumpCoyoteTime;
        }
        isTouchingWall = Physics2D.Raycast(wallCheck.position, transform.right, data.wallCheckDistance, whatIsGround);
        if (Physics2D.OverlapBox(frontWallCheck.position, wallCheckSize, 0, whatIsGround))
        {
            lastOnWallTime = data.jumpCoyoteTime;
        }
    }

    private void Flip()
    {
        if (canFlip && !isKnockback)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0.0f, 180.0f, 0.0f);
            facingDirection *= -1;
        } 
    }

    public void DisableFlip()
    {
        canFlip = false;
    }

    public void EnableFlip()
    {
        canFlip = true;
    }

    private void RunHandler()
    {
        Vector2 inputVector = gameInput.GetMovementNormalized();

        moveDir = new Vector3(inputVector.x, inputVector.y, 0f);
        if(moveDir != Vector3.zero )
        {
            isRunning= true;
        }
        else
        {
            isRunning= false;
        }

        if (canMove && !isKnockback)
        {
            rb.velocity = new Vector2(data.runSpeed * moveDir.x, rb.velocity.y);
        }
       
    }

    private void Jump()
    {
        lastPressedJumpTime = 0;
        lastGroundedTime = 0;

        float force = data.jumpPower;
        if(rb.velocity.y < 0)
        {
            force -= rb.velocity.y;
        }
        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        //if (canJump)
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, data.jumpPower);
        //    amountOfJumpsLeft--;
        //}  
    }

    private void WallJump()
    {
        lastPressedJumpTime = 0;
        lastGroundedTime = 0;
        lastOnwallRight = 0;
        lastOnWallLeft = 0;

        Vector2 force = new Vector2(data.wallJumpForceX, data.wallJumpForceY);

        if (Mathf.Sign(rb.velocity.x) != Mathf.Sign(force.x))
           force.x -= rb.velocity.x;
        if(rb.velocity.y < 0)
        {
            force.y -= rb.velocity.y;
        }
        Flip();
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    private void CancelJump()
    {
        if(rb.velocity.y >= 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }

    private void DashHandler()
    {
        if (isDashing)
        {
            if (dashTimeLeft > 0)
            {
                canMove = false;
                canFlip = false;
                rb.velocity = new Vector2(data.dashSpeed * facingDirection, 0.0f);
                dashTimeLeft -= Time.deltaTime;

                if (Mathf.Abs(transform.position.x - lastImageXPos) > data.distanceBetweenDashImage)
                {
                    PlayerAfterImagePool.Instance.GetFromPool();
                    lastImageXPos = transform.position.x;
                }
            }

            if (dashTimeLeft <= 0 || isTouchingWall)
            {
                isDashing = false;
                canMove = true;
                canFlip = true;
            }

        }
    }

    private void WallSlideHandler()
    {
        if (isWallSlide)
        {
            Debug.Log("WallSlide");
            if(rb.velocity.y < -data.wallSlideSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, -data.wallSlideSpeed);
            }
        }
    }

    private void AttempToDash()
    {
        isDashing = true;
        dashTimeLeft = data.dashTime;
        lastDash = Time.time;

        PlayerAfterImagePool.Instance.GetFromPool();
        lastImageXPos = transform.position.x;

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheckPoint.position, data.groundCheckRadius);
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + data.wallCheckDistance, wallCheck.position.y));
        Gizmos.DrawWireCube(frontWallCheck.position, wallCheckSize);
    }

    private bool CanWallJump()
    {
        return lastPressedJumpTime > 0 && lastOnWallTime > 0 && lastGroundedTime <= 0 ;
    }

}
