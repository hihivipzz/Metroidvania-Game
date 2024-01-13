using UnityEngine;

public class Treasure : MonoBehaviour
{
    [SerializeField]
    private ItemBase item;

    public ItemBase Item { get { return item; } }
}
