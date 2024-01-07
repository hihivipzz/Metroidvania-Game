using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator = null;
    private PlayerCombatController playerCombatControler;
    private PlayerMovementController playerMovementControler;
    private Rigidbody2D rb;

    private const string IS_ATTACKING = "isAttacking";
    private const string FIRST_ATTACK = "firstAttack";
    private const string CAN_ATTACK = "canAttack";
    private const string ATTACK1 = "attack1";
    private const string ATTACK2 = "attack2";
    private const string ATTACK3 = "attack3";
    private const string IS_RUNNING = "isRun";
    private const string IS_GROUNDED = "isGrounded";
    private const string Y_VELOCITY = "yVelocity";
    private const string IS_DASHING = "isDashing";
    private const string IS_DOUBLEJUMP = "doubleJump";

    [SerializeField]private GameObject doubleJumpEffect;

    void Awake()
    {
        
        
        
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerCombatControler = GetComponent<PlayerCombatController>();
        playerMovementControler = GetComponent<PlayerMovementController>();
        rb = GetComponent<Rigidbody2D>();
        playerMovementControler.OnDoubleJump += PlayerMovementControler_OnDoubleJump;
    }

    private void PlayerMovementControler_OnDoubleJump(object sender, System.EventArgs e)
    {
        Vector2 movementDirection = rb.velocity.normalized;
        float angle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg;
        GameObject effect = Instantiate(doubleJumpEffect,this.transform.position, Quaternion.Euler(new Vector3(0, 0, angle)));
        Destroy(effect, 3f);
    }

    private void Update()
    {
        animator.SetBool(IS_RUNNING, playerMovementControler.isRunning);
        animator.SetBool(IS_GROUNDED, playerMovementControler.isGrounded);
        animator.SetFloat(Y_VELOCITY, rb.velocity.y);
        animator.SetBool(IS_DASHING, playerMovementControler.isDashing);

        animator.SetBool(CAN_ATTACK, playerCombatControler.combatEnabled);
        animator.SetBool(IS_ATTACKING, playerCombatControler.isAttacking);
        animator.SetBool(ATTACK1,playerCombatControler.playerAttack1.GetStatus());
        animator.SetBool(ATTACK2,playerCombatControler.playerAttack2.GetStatus());
        animator.SetBool(ATTACK3, playerCombatControler.playerAttack3.GetStatus());

       
    }

    public void RunAnimation(bool isRunning)
    {
        animator.SetBool("isRun", isRunning);
    }

    public void JumpAnimation(bool isJump)
    {
        animator.SetFloat("JumpY", isJump ? 2f : 0.1f);
    }

    public void WalkAnimation(bool isWalk)
    {
        animator.SetBool("isWalk", isWalk);
    }

    public void TriggerAttack(int attackNumber)
    {
        animator.SetTrigger("attack" + attackNumber);
    }

    public void DeadAnimation(bool isDead)
    {
        animator.SetBool("isDead", isDead);
    }

    public void SurfingAnimation(bool isSurfing)
    {
        animator.SetBool("isSurfing", isSurfing);
    }

    public void HurtAnimation(bool isHurt)
    {
        animator.SetBool("isHurt", isHurt);
    }
}
