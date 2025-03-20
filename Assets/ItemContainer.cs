using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    [SerializeField] private ItemData itemData;
    [SerializeField] private int amount;
    private Item item;
    public Item GetItem => item;

    private void Awake()
    {
        item = new Item(itemData, amount);
    }
}
