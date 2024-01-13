using UnityEngine;

public class SavePointController : MonoBehaviour
{
    public float ACTIVE_DISTANCE = 2f;
    public GameInput gameInput;
    public LayerMask playerLayer;
    private Animator animator;
    private bool isActive = false;
    public SavePointManager savePointManager;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        DetectPlayerToActive();
    }

    private void FixedUpdate()
    {
        if (!isActive)
        {
            savePointManager.CloseDialog();
        }
    }

    private void OnEnable()
    {
        gameInput.OnOpenSavePointAction += GameInput_OnOpenSavePointAction;
    }

    public void GameInput_OnOpenSavePointAction(object sender, System.EventArgs e)
    {
        if (isActive)
        {
            savePointManager.StartDialog();
        }
    }

    public void DetectPlayerToActive()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, ACTIVE_DISTANCE, playerLayer);
        isActive = !!playerCollider;
    }
}
