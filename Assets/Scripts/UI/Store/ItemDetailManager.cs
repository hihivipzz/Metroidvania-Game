using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailManager : MonoBehaviour
{
    private ItemBase currentItem;
    public Image imageItemComponent;
    public TextMeshProUGUI descriptionItemComponent;

    private void Start()
    {
        currentItem = FindAnyObjectByType<ItemBase>();
        ChangeDetailItem(currentItem);
    }

    public void ChangeDetailItem(ItemBase item)
    {
        currentItem = item;
        descriptionItemComponent.text = item.description;
        imageItemComponent.sprite = item.image;
    }

    public void HandleBuy()
    {
        if (currentItem.price == 0)
        {
            Debug.Log("Hang free");
        }
    }
}
