using UnityEngine;

public class TreasureManager : MonoBehaviour
{
    public PlayerBag playerBag;
    public Animator animator;
    public bool isOpen = false;
    private Treasure treasure;

    private void FixedUpdate()
    {
        animator.SetBool("IsOpenTreasureDialogue", isOpen);
    }

    public void StartDialog(Treasure treasure)
    {
        isOpen = true;
        this.treasure = treasure;
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
}
