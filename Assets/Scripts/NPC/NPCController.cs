using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class NPCController : MonoBehaviour
{
    public float detectionRadius = 5f;
    public float ACTIVE_TALK_DISTANCE = 1f;
    public LayerMask playerLayer;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private UnityEvent onClickEvent = new UnityEvent();
    public bool IsTalking { get; set; } = false;
    public bool isActiveTalk = false;
    [SerializeField] private GameInput gameInput;

    void Awake() 
    {
        
    }

    private void OnEnable()
    {
        gameInput.OnTalkAction += GameInput_OnTalkAction;
    }

    private void GameInput_OnTalkAction(object sender, System.EventArgs e)
    {
        if (!IsTalking && isActiveTalk)
        {
            onClickEvent.Invoke();
            IsTalking = true;
        }
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        DetectPlayer();
        DetectPlayerToActiveTalk();
    }

    private void FixedUpdate()
    {
        if (!isActiveTalk && IsTalking)
        {
            FindAnyObjectByType<DialogueManager>().EndDialogue();
            IsTalking = false;
        }
    }

    public void DetectPlayer()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer);

        if (playerCollider != null)
        {
            Vector3 playerPosition = playerCollider.transform.position;

            if (playerPosition.x > transform.position.x && spriteRenderer.flipX)
            {
                Flip();
            }
            else if (playerPosition.x < transform.position.x && !spriteRenderer.flipX)
            {
                Flip();
            }
        }
    }

    public void DetectPlayerToActiveTalk()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, ACTIVE_TALK_DISTANCE, playerLayer);
        isActiveTalk = !!playerCollider;
    }

    public void Flip()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
