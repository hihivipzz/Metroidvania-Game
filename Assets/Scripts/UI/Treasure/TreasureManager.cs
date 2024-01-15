using UnityEngine;

public class TreasureManager : MonoBehaviour
{
    public  static TreasureManager Instance;
    public Transform itemInTreasure;
    public PlayerBag playerBag;
    private Animator animator;
    public bool isOpen = false;
    private Treasure treasure;

    private void Awake()
    {
        Instance= this;
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        animator.SetBool("IsOpenTreasureDialogue", isOpen);
    }

    public void StartDialog(Treasure treasure)
    {
        isOpen = true;
        this.treasure = treasure;
        Draw(treasure.Item);
    }

    public void CloseDialog()
    {
        isOpen = false;
    }

    public void YesOnClick()
    {
        playerBag.AddItemToBag(treasure.Item);
        CloseDialog();
    }

    public void Draw(ItemBase item)
    {
        Vector3 spawnPosition = itemInTreasure.transform.position;
        GameObject spawnedItem = Instantiate(item.gameObject, spawnPosition, Quaternion.identity);
        spawnedItem.transform.SetParent(itemInTreasure.transform, false);
        spawnedItem.transform.localPosition = Vector3.zero;
    }
}
