using System;

public class SimpleModel : ItemModel
{
    public SimpleModel(ItemData data) : base(data) {}
    public SimpleModel(ItemData data, ItemView itemView, int count) : base(data, itemView, count) {}

    public override ItemModel PickUp(InventoryModel inventory, ref int index) 
    {
        index = Array.IndexOf(inventory.items, null);
        if (index == -1) return null;
        
        itemView = inventory.view.AddItem(index);
        itemView.itemModel = this;
        itemView.Refresh();

        return this;
    }
}