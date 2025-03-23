using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    [SerializeField] private ItemData itemData;
    [SerializeField] private int amount;
    private Item item;
    public Item GetItem => item;
    public int Amount 
    {
        get => amount;
        set 
        {
            if (amount == value) return;

            amount = value;
            CreateItem();
        }   
    }
    public ItemData ItemData 
    {
        get => itemData;
        set 
        {
            if (itemData == value) return;
            
            itemData = value;
            CreateItem();
        }
    }

    public Item CreateItem() 
    {
        return item = new Item(itemData, amount);
    }
}
