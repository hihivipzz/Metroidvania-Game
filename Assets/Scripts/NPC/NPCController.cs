using UnityEngine;
using UnityEngine.Events;

public class NPCController : MonoBehaviour
{
    public float detectionRadius = 5f;
    public float ACTIVE_TALK_DISTANCE = 1f;
    public LayerMask playerLayer;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private UnityEvent onClickEvent = new UnityEvent();
    public bool isActiveTalk = false;
    [SerializeField] private GameInput gameInput;
    public DialogueManager dialogueManager;
    public StoreManager storeManager;

    private void OnEnable()
    {
        gameInput.OnTalkAction += GameInput_OnTalkAction;
    }

    private void GameInput_OnTalkAction(object sender, System.EventArgs e)
    {
        if (isActiveTalk)
        {
            onClickEvent.Invoke();
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

        if (!isActiveTalk)
        {
            dialogueManager.EndDialogue();
            storeManager.CloseStore();
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
