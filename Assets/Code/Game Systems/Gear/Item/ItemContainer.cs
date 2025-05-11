using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    [SerializeField] private ElementData elementData;
    [SerializeField] private int amount;
    
    private Item item = new Item();
    public Item GetItem => item;
    public int Amount 
    {
        get => amount;
        set => amount = item.Amount + value;
    }
    public ElementData ElementData 
    {
        get => elementData;
        set => elementData = item.data = value;
    }

    public void CreateNewItem(Item item)
    {
        this.item = item;
    }

    private void Start()
    {
        item = new Item(elementData, amount);
    }
}
