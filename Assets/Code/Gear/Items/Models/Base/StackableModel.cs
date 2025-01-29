using System;
using System.Linq;
public class StackableModel : ItemModel 
{
    public StackableModel(ItemData data, int count = 1) : base(data, count){}
    public StackableModel(ItemData data, ItemView itemView, int count) : base(data, itemView, count){}

    public override ItemModel PickUp(InventoryModel inventory, ref int index)
    {
        int countToPut;

        var notFullCollections = inventory.items.Where(
                state => state != null
                && state.GetType() == GetType() //такого же типа
                && state.data.GetId == data.GetId // такой же предмет
                && state.count < data.GetMaxStackSize) // и его стак не заполнен
            .ToList();
            
        foreach (var state in notFullCollections) //если нашли - заполняем его
        {
            countToPut = Math.Min(count, state.data.GetMaxStackSize - state.count);

            state.count += countToPut;
            count -= countToPut;

            state.itemView.Refresh();

            if (count <= 0) return null;
        }
        
        index = Array.IndexOf(inventory.items, null);
        if (index == -1 || count <= 0) return null;

        countToPut = Math.Min(count, data.GetMaxStackSize);

        itemView = inventory.view.AddItem(index);
        itemView.itemModel = this;
        itemView.Refresh();

        return this;
    }
}