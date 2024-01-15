using System.Collections;
using UnityEngine;

public class TreasureController : MonoBehaviour
{


    public float ACTIVE_DISTANCE = 2f;
    public float WAITING_TIME = 1f;
    private Animator animator;
    private bool isOpen = false;
    public GameObject itemDisplay;
    public Treasure treasure;

    private void Awake()
    {
        isOpen = false;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {

    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        animator.SetBool("IsOpenTreasure", isOpen);
    }


    IEnumerator WaitForOpenDialog()
    {
        yield return new WaitForSeconds(WAITING_TIME);
        TreasureManager.Instance.StartDialog(treasure);
    }

    public void OpenTreasure()
    {
        if (!isOpen)
        {
            isOpen = true;
            StartCoroutine(WaitForOpenDialog());
        }
     

        
    }
}
