using System.Collections;
using UnityEngine;

public class TreasureController : MonoBehaviour
{
    public float ACTIVE_DISTANCE = 2f;
    public float WAITING_TIME = 1f;
    private Animator animator;
    private bool isOpen = false;
    public GameObject itemDisplay;
    public LayerMask playerLayer;
    public Treasure treasure;
    public bool isActive = false;
    public GameInput gameInput;
    public TreasureManager treasureManager;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        gameInput.OnOpenTreasureAction += GameInput_OnOpenTreasureAction;
    }

    void Update()
    {
        DetectPlayerToActive();
    }

    private void FixedUpdate()
    {
        animator.SetBool("IsOpenTreasure", isOpen);
    }

    private void GameInput_OnOpenTreasureAction(object sender, System.EventArgs e)
    {
        if (!isOpen && isActive)
        {
            OpenTreasure();
            StartCoroutine(WaitForOpenDialog());
        }
    }

    IEnumerator WaitForOpenDialog()
    {
        yield return new WaitForSeconds(WAITING_TIME);
        treasureManager.StartDialog(treasure);
    }

    public void OpenTreasure()
    {
        if (!isActive)
        {
            return;
        }

        if (treasure != null && itemDisplay != null)
        {
            Vector3 spawnPosition = itemDisplay.transform.position;
            GameObject spawnedItem = Instantiate(treasure.Item.gameObject, spawnPosition, Quaternion.identity);
            spawnedItem.transform.SetParent(itemDisplay.transform, false);
            spawnedItem.transform.localPosition = Vector3.zero;
        }

        isOpen = true;
    }

    public void DetectPlayerToActive()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, ACTIVE_DISTANCE, playerLayer);
        isActive = !!playerCollider;
    }
}
