using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public Animator animator;
    private bool isOpen = false;
    public Player player;
    public ItemDetailManager itemDetailManager;
    private int status = -1;


    private void FixedUpdate()
    {
        animator.SetBool("IsOpen", isOpen);
    }

    public void OpenStore()
    {
        status = 1;
        isOpen = true;
    }

    public void CloseStore()
    {
        status = -1;
        isOpen = false;
    }

    public void HandleBuyItem()
    {
        ItemBase itemToBuy = itemDetailManager.GetCurrentItem();
        var playerBag = player.GetComponent<PlayerBag>();

        if (itemToBuy.IsAffordToBuy(player.coinNumber))
        {
            player.ChangeCoin(player.coinNumber - itemToBuy.price);
            playerBag.AddItemToBag(itemToBuy);
        }
    }

    public int GetStatus()
    {
        return status;
    }
}
