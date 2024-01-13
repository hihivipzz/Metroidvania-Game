using UnityEngine;
using UnityEngine.UI;

public class ItemBase : MonoBehaviour
{
    [SerializeField]
    public Sprite image;
    public int price;
    public string description;
    public int type;
    public float sizeImage = 30f;

    private void Start()
    {
        InitImageItem();
    }

    private void Update()
    {
    }

    public void InitImageItem()
    {
        GameObject imageObject = new GameObject("ImageItem");
        Image imageComponent = imageObject.AddComponent<Image>();
        imageComponent.sprite = image;
        imageObject.transform.SetParent(transform, false);
        imageObject.transform.localPosition = Vector3.zero;
        RectTransform rectTransform = imageObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(sizeImage, sizeImage);
    }

    public void OnClick()
    {
        FindAnyObjectByType<ItemDetailManager>().ChangeDetailItem(this);
    }

    public bool IsAffordToBuy(int playerCoin)
    {
        PlayerBag playerBag = FindAnyObjectByType<PlayerBag>();
        return playerCoin >= price && playerBag.IsAvailable();
    }
}
