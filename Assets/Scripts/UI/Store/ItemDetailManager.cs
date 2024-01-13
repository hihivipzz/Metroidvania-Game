using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailManager : MonoBehaviour
{
    private ItemBase currentItem;
    public Image imageItemComponent;
    public TextMeshProUGUI descriptionItemComponent;
    public TextMeshProUGUI priceItemComponent;

    private void Start()
    {
        currentItem = FindAnyObjectByType<ItemBase>();
        ChangeDetailItem(currentItem);
    }

    public void ChangeDetailItem(ItemBase item)
    {
        currentItem = item;
        descriptionItemComponent.text = item.description;
        priceItemComponent.text = item.price.ToString();
        imageItemComponent.sprite = item.image;
    }

    public ItemBase GetCurrentItem()
    {
        return currentItem;
    }
}
