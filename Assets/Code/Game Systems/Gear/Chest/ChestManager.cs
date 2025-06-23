public class ChestManager : InventoryTypeManager
{
    public ChestManager(GearStorage storage) : base(storage) {}

    public Item[] TakeItems() 
    {
        Item[] items = new Item[storage.Items.Length];

        for (int i = 0; i < storage.Items.Length; i++)
        {
            Item item = storage.GetItem(i);
            items[i] = new Item(item.data, item.Amount);
            RemoveItem(i);
        }   

        return items;
    }
}