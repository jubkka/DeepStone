using System;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryTypeManager : GearManager {
    public InventoryTypeManager(GearStorage storage) : base(storage) {}

    public override bool AddItem(Item item, int index = -1) 
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

    private bool StackItem(Item item)
    {
        bool added = false;

        for (int index = 0; index < storage.Items.Length; index++) // пробегаемся по всему инвенторю
        {
            if (item.Amount <= 0) break;

            Item itemInInv = storage.Items[index];
            
            bool match = 
                !itemInInv.IsEmpty && //Пустая ли ячейка
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
        int freeIndex = Array.FindIndex(storage.Items, itemNull => itemNull.IsEmpty);
        
        bool added = 
            index != -1 && //Индекс не должен быть отрицательным
            freeIndex != -1 && // В слоте не должен быть предмет
            PlaceItemByIndex(item, freeIndex); //Размещаем

        // while (--amount > 0)
        // {
        //     int freeIndex = Array.FindIndex(storage.Items, itemNull => itemNull.IsEmpty); //Ищем индекс пустой ячейки в инвентаре
        //     
        //     if (freeIndex == -1) break;
        //
        //     added = PlaceItemByIndex(item, freeIndex);
        // }

        return added;
    }

    public bool PlaceItemByIndex(Item item, int index) 
    {
        int countToPut = Math.Min(item.Amount, item.GetMaxStackSize);
        item.Amount = countToPut;
        storage.SetItem(item, index);
        item.OnItemCountZero += Remove;

        InvokeItemChanged(index);

        return true;
    }

    private void Remove(Item item) 
    {
        for (int i = 0; i < storage.Items.Length; i++)
        {
            if (storage.GetItem(i) == item) 
                RemoveItem(i);
        }
    }

    public override bool RemoveItem(int index)
    {
        if (storage.Items[index] == null) return false;

        storage.Items[index] = new Item();
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