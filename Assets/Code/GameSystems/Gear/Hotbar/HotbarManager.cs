public class HotbarManager : GearManager
{
    public HotbarManager(GearStorage storage) : base(storage) {}

    public override bool AddItem(Item item, int index)
    {
        storage.SetItem(item, index);
        InvokeItemAdded(index);

        return true;
    }

    public override bool RemoveItem(int index) 
    {
        if (storage.Items[index] == null) return false;

        storage.Items[index] = new Item();
        InvokeItemAdded(index);

        return true;
    }

    public override bool MoveItems(int fromIndex, int targetIndex)
    {
        if (fromIndex == targetIndex) return false;

        Item fromItem = storage.Items[fromIndex];
        Item targetItem = storage.Items[targetIndex];

        IMoveCommand moveCommand;

        if (!fromItem.IsEmpty && targetItem.IsEmpty)
        {
            moveCommand = new MoveToEmptySlotCommand(fromIndex, targetIndex);
        }
        else
        {
            moveCommand = new SwapItemsCommand(fromIndex, targetIndex);
        }   

        if (moveCommand.Execute(storage.Items)) 
        {
            InvokeItemAdded(fromIndex);
            InvokeItemAdded(targetIndex);
            return true;
        }

        return false;
    }
}