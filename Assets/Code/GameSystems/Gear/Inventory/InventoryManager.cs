using System;

public class InventoryManager : GearManager
{
    public InventoryManager(GearStorage storage) : base(storage) {}
    public override bool AddItem(Item item, int index) 
    {
        if (item.data is StackableItemData)
        {
            bool stacked = StackItem(item);
            
            if (item.Amount > 0) 
            {
                bool placed = PlaceItem(item, index);
                return placed || stacked;
            }

            return stacked;
        }
    
        return PlaceItem(item, index);
    }
    public override bool RemoveItem(int index)
    {
        if (storage.Items[index] == null) return false;

        storage.Items[index] = new Item();
        InvokeItemChanged(index);

        return true;
    }
    private bool StackItem(Item item)
    {
        bool added = false;

        for (int index = 0; index < storage.Items.Length; index++) // пробегаемся по всему инвенторю
        {
            if (item.Amount <= 0) break;

            Item itemInInv = storage.Items[index];
            
            bool match = !itemInInv.IsEmpty && //Пустая ли ячейка
                itemInInv.data.GetId == item.data.GetId && // Такого же типа предмет
                itemInInv.Amount < item.GetMaxStackSize; // есть еще место в стаке

            if (match) 
            {
                int countToPut = Math.Min(item.Amount, itemInInv.GetMaxStackSize - itemInInv.Amount); //кладем не больше лимита размера стака

                if (countToPut > 0) 
                {
                    itemInInv.Amount += countToPut;
                    item.Amount -= countToPut;

                    added = true;
                    InvokeItemChanged(index);
                }
            }

        }

        return added;
    }
    private bool PlaceItem(Item item, int index) 
    {
        bool added = index != -1 && //Индекс не должен быть отрицательным
            storage.GetItem(index).data == null && // В слоте не должен быть предмет
            PlaceItemByIndex(item, index); //Размещаем

        while (item.Amount > 0)
        {
            int freeIndex = Array.FindIndex(storage.Items, item => item != null && item.IsEmpty); //Ищем индекс пустой ячейки в инвентаре
            
            if (freeIndex == -1) break;

            added = PlaceItemByIndex(item, freeIndex);
        }

        return added;
    }
    private bool PlaceItemByIndex(Item item, int index) 
    {
        int maxStackSize = item.GetMaxStackSize;

        int countToPut = Math.Min(item.Amount, maxStackSize);
        Item newItem = new Item(item.data, countToPut);
        storage.SetItem(newItem, index);
        item.Amount -= countToPut;

        InvokeItemChanged(index);

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
        else if (fromItem.data.GetId == targetItem.data.GetId)
        {
            moveCommand = new StackItemsCommand(fromIndex, targetIndex);
        }
        else
        {
            moveCommand = new SwapItemsCommand(fromIndex, targetIndex);
        }   

        if (moveCommand.Execute(storage.Items)) 
        {
            InvokeItemChanged(fromIndex);
            InvokeItemChanged(targetIndex);
            return true;
        }

        return false;
    }
}