public class ChestComponent : GearComponent {
    public override void Initialize() 
    {
        Storage = new GearStorage(maxSize);
        Manager = new ChestManager(Storage);

        base.Initialize();
    }
    
    public bool GiveItems(Item[] items)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if(!Manager.AddItem(items[i], i)) 
                return false;
        }    
        return true;
    }
    
    public Item[] TakeItems() 
    {
        Item[] items = new Item[maxSize];

        for (int i = 0; i < Storage.Items.Length; i++)
        {
            Item item = GetItem(i);
            items[i] = new Item(item.data, item.Amount);
            RemoveItem(i);
        }   

        return items;
    }
    public override bool MoveItems(int fromIndex, int targetIndex)
    {
        if (Manager.MoveItems(fromIndex, targetIndex)) 
            return true;

        return false;
    }
}