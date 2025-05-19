public class HotbarManager : GearManager
{
    public HotbarManager(GearStorage storage) : base(storage) {}

    public override bool AddItem(Item item, int index)
    {
        if (item == null) return false;
        
        Storage.SetItem(item, index);
        InvokeItemChanged(index);
        
        return true;
    }

    public override bool RemoveItem(int index) 
    {
        if (Storage.Items[index] == null) return false;
        
        Storage.Items[index] = new Item();
        InvokeItemChanged(index);
        
        return true;
    }

    public override bool MoveItems(int fromIndex, int targetIndex)
    {
        if (fromIndex == targetIndex) return false;

        Item fromItem = Storage.Items[fromIndex];
        Item targetItem = Storage.Items[targetIndex];

        IMoveCommand moveCommand;

        if (!fromItem.IsEmpty && targetItem.IsEmpty)
        {
            moveCommand = new MoveToEmptySlotCommand(fromIndex, targetIndex);
        }
        else
        {
            moveCommand = new SwapItemsCommand(fromIndex, targetIndex);
        }   

        if (moveCommand.Execute(Storage.Items)) 
        {
            InvokeItemChanged(fromIndex);
            InvokeItemChanged(targetIndex);
            return true;
        }

        return false;
    }
}