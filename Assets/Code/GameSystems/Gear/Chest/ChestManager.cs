public class ChestManager : InventoryTypeManager
{
    public ChestManager(GearStorage storage) : base(storage) {}

    public bool AddItems(Item[] items) 
    {
        for (int i = 0; i < items.Length; i++)
        {
            if(!AddItem(items[i], i)) 
                return false;
        }    
        return true;
    } 
}