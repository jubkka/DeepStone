using System;

[Serializable]
public class ItemSlot 
{
    public Item item;
    public int amount;
    public bool IsEmpty { get => item == null; }

    public ItemSlot() {}
    public ItemSlot(Item item, int amount) 
    {
        this.item = item;
        this.amount = amount;
    }

    public string Use() 
    {
        amount -= 1;

        return item.GetName;
    }
}