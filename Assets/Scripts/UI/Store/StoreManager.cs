using System;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public static event EventHandler OnBuySuccess;
    public static event EventHandler OnBuyError;
    public static StoreManager Instance { get; private set; }
    private Animator animator;
    private bool isOpen = false;
    public Player player;
    public ItemDetailManager itemDetailManager;
    private int status = -1;

    private void Awake()
    {
        Instance= this;
        animator= GetComponent<Animator>();
    }

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
            OnBuySuccess?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            OnBuyError?.Invoke(this, EventArgs.Empty);
        }
    }

    public int GetStatus()
    {
        return status;
    }
}
