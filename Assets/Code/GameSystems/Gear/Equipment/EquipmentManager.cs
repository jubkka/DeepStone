public class EquipmentManager : GearManager
{
    public EquipmentManager(GearStorage storage) : base(storage) {}

    public override bool AddItem(Item item, int index)
    {
        if (item == null) return false;

        storage.SetItem(item, index);
        InvokeItemChanged(index);

        return true;
    }
    public override bool RemoveItem(int index)
    {
        if (storage.Items[index] == null) return false;

        storage.Items[index] = new Item();
        InvokeItemChanged(index);

        return true;
    }
    
    public override bool MoveItems(int fromIndex, int targetIndex) { return false;}
}