using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayBagController : MonoBehaviour
{
    private PlayerBag playerBag;
    private Animator animator;
    public bool isOpen = false;
    public ItemBase itemPrefab;

    private void Start()
    {
        playerBag = FindAnyObjectByType<PlayerBag>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        animator.SetBool("IsOpenBag", isOpen);
    }

    public void OpenBag()
    {
        if (isOpen)
        {
            CloseBag();
            return;
        }

        isOpen = true;
        ShowItems();
    }

    public void CloseBag()
    {
        isOpen = false;
    }

    private void ShowItems()
    {
        ClearItems();

        foreach (ItemBase item in playerBag.bagItems)
        {
            ItemBase newItem = Instantiate(itemPrefab, transform.position, Quaternion.identity);

            newItem.image = item.image;
            newItem.price = item.price;
            newItem.description = item.description;
            newItem.type = item.type;
            Button button = newItem.GetComponent<Button>();

            button.onClick.AddListener(() => OnClickItem(item));

            newItem.transform.SetParent(transform, false);
        }

        int emptySlots = playerBag.NumberOfEmptySlot();
        DrawEmptySlot(emptySlots);
    }

    private void OnClickItem(ItemBase itemBase)
    {
        ItemAffect itemAffect = ItemAffectFactory.Instance.CreateAffect(itemBase.type);
        itemAffect.Affect();
        playerBag.bagItems.Remove(itemBase);
        ShowItems();
    }

    private void ClearItems()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void DrawEmptySlot(int emptySlots)
    {
        foreach (int _slotNumber in Enumerable.Range(1, emptySlots))
        {
            ItemBase newItem = Instantiate(itemPrefab, transform.position, Quaternion.identity);
            newItem.transform.SetParent(transform, false);
        }
    }
}
