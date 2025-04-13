using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    [SerializeField] private ItemData itemData;
    [SerializeField] private int amount;
    
    private Item item = new Item();
    public Item GetItem => item;
    public int Amount 
    {
        get => amount;
        set => amount = item.Amount + value;
    }
    public ItemData ItemData 
    {
        get => itemData;
        set => itemData = item.data = value;
    }

    public void CreateNewItem(Item item)
    {
        this.item = item;
    }

    private void Start()
    {
        item = new Item(itemData, amount);
    }
}
