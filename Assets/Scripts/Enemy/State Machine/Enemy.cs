using UnityEngine;

public class Enemy : MonoBehaviour
{
    public FiniteStateMachine stateMachine;

    public D_Enemy enemyData;

    public int facingDirection { get; private set; }

    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }
    public AnimationToStateMachine atsm { get; private set; }

    private Vector2 velocityWorkSpace;

    private float currentHealth;

    private int lastDamageDirection;
    public bool applyKnockBack { get; private set; }
    public bool isKnockingBack { get; private set; }
    private float knockBackStart;

    protected bool isDead;

    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheck;
    [SerializeField] private Transform playerCheck;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform sprite;


    public virtual void Start()
    {
        facingDirection = 1;
        currentHealth = enemyData.maxHealth;
        applyKnockBack = true;

        isDead = false;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        atsm = GetComponent<AnimationToStateMachine>();

        stateMachine = new FiniteStateMachine();
    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
        CheckKnockback();
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velocity)
    {
        velocityWorkSpace.Set(facingDirection * velocity, rb.velocity.y);
        rb.velocity = velocityWorkSpace;
    }

    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        velocityWorkSpace.Set(angle.x * velocity * direction, angle.y * velocity);
        rb.velocity = velocityWorkSpace;
    }

    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(wallCheck.position, this.transform.right, enemyData.wallCheckDistance, enemyData.whatIsGround);
    }

    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, enemyData.ledgeCheckDistance, enemyData.whatIsGround);
    }

    public virtual bool CheckGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, enemyData.groundCheckRadius, enemyData.whatIsGround);
    }

    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, gameObject.transform.right, enemyData.minAgroDistance, enemyData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInManAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, gameObject.transform.right, enemyData.maxAgroDistance, enemyData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(playerCheck.position, gameObject.transform.right, enemyData.closeRangeActionDistance, enemyData.whatIsPlayer);
    }

    public virtual void Flip()
    {
        facingDirection *= -1;
        this.transform.Rotate(0f, 180f, 0f);

    }

    public virtual void DamageHop(float velocity)
    {
        velocityWorkSpace.Set(rb.velocity.x, velocity);
        rb.velocity = velocityWorkSpace;
    }

    public void SetApplyKnockBack(bool applyKnockBack)
    {
        this.applyKnockBack = applyKnockBack;
    }

    public virtual void KnockBack()
    {
        isKnockingBack = true;
        knockBackStart = Time.time;
        velocityWorkSpace.Set(enemyData.knockbackSpeedX * lastDamageDirection, enemyData.knockbackSpeedY);
        rb.velocity = velocityWorkSpace;
    }

    private void CheckKnockback()
    {
        if (Time.time >= knockBackStart + enemyData.knockbackDuration && isKnockingBack)
        {
            isKnockingBack = false;
            rb.velocity = new Vector2(0, rb.velocity.y);

            if (lastDamageDirection == facingDirection)
            {
                Flip();
            }
        }
    }

    public virtual void Damage(AttackDetails attackDetails)
    {
        if (!isDead)
        {

            currentHealth -= attackDetails.damageAmount;

            //DamageEffect
            sprite.GetComponent<FlashEffect>()?.Flash();

            //DamageHop(enemyData.damageHopSpeed);

            if (attackDetails.position.x > gameObject.transform.position.x)
            {
                lastDamageDirection = -1;
            }
            else
            {
                lastDamageDirection = 1;
            }

            if (applyKnockBack && currentHealth > 0.0f)
            {
                KnockBack();
            }

            if (currentHealth <= 0.0f)
            {
                isDead = true;
            }
        }
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * enemyData.wallCheckDistance));
        Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * enemyData.ledgeCheckDistance));

        Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(gameObject.transform.right * enemyData.closeRangeActionDistance), 0.2f);
        Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(gameObject.transform.right * enemyData.minAgroDistance), 0.2f);
        Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(gameObject.transform.right * enemyData.maxAgroDistance), 0.2f);
    }

    public virtual void Dead()
    {
        CoinManager.Instance.SpawnCoin(10, gameObject.transform.position);
        Destroy(gameObject);
    }

}
