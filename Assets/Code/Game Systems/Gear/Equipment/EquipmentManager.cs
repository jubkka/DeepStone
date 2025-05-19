public class EquipmentManager : GearManager
{
    public EquipmentManager(GearStorage storage) : base(storage) {}

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

    public override bool MoveItems(int fromIndex, int targetIndex) { return false;}
    
}