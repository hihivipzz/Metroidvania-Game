using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBag : MonoBehaviour
{
    [SerializeField] GameInput gameInput;
    public List<ItemBase> bagItems { get; private set; }
    public static int MAX_ITEMS_IN_BAG = 25;

    [SerializeField]
    PlayBagController playBagController;

    private void Awake()
    {
        bagItems = new List<ItemBase>();
    }

    private void Start()
    {
        gameInput.OnOpenBagAction += GameInput_OnOpenBagAction;
    }

    private void GameInput_OnOpenBagAction(object sender, EventArgs e)
    {
        playBagController.OpenBag();
    }

    public void AddItemToBag(ItemBase item)
    {
        bagItems.Add(item);
        Debug.LogError("Mua rooif " + item.name);
    }

    public void RemoveItem(ItemBase item)
    {
        bagItems.Remove(item);
    }

    public bool IsAvailable()
    {
        return bagItems.Count < MAX_ITEMS_IN_BAG;
    }

    public int NumberOfEmptySlot()
    {
        return MAX_ITEMS_IN_BAG - bagItems.Count;
    }
}
