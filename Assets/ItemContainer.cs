using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    [SerializeField] private ItemData itemData;
    [SerializeField] private int amount;
    public Item item;

    private void Awake()
    {
        item = new Item(itemData, amount);
    }
}
