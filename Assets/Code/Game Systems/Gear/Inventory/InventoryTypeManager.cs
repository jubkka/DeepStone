using System;
using UnityEngine;

public class InventoryTypeManager : IGearManager 
{
    protected GearStorage storage;
    public event Action<int> OnItemChanged;
    public event Action<Item> OnItemAdded;
    public event Action<Item> OnItemRemoved;
    public event Action<Item> OnItemDropped;
    public event Action<Item> OnItemCountZero;

    protected InventoryTypeManager(GearStorage storage)
    {
        this.storage = storage;
    }

    public bool AddItem(Item item, int index = -1)
    {
        if (item.data is null)
            return false;
        
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

        for (int index = 0; index < storage.Items.Length; index++) // пробегаемся по всему инвентарю
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
                    OnItemChanged?.Invoke(index);
                    OnItemAdded?.Invoke(itemInInv);
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

        OnItemChanged?.Invoke(index);
        OnItemAdded?.Invoke(item);

        return true;
    }

    private void Remove(Item item) 
    {
        for (int i = 0; i < storage.Items.Length; i++)
        {
            if (storage.GetItem(i) == item)
            {
                //OnItemCountZero?.Invoke(storage.Items[i]);
                RemoveItem(i);
            }
        }
    }

    public bool RemoveItem(int index)
    {
        if (storage.Items[index] == null) 
            return false;
        
        OnItemRemoved?.Invoke(storage.Items[index]);
        
        storage.Items[index] = new Item();
        OnItemChanged?.Invoke(index);

        return true;
    }

    public bool DropItem(int index)
    {
        OnItemDropped?.Invoke(storage.GetItem(index));
        return RemoveItem(index);
    }

    public bool MoveItems(int fromIndex, int targetIndex) 
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
            OnItemChanged?.Invoke(fromIndex);
            OnItemChanged?.Invoke(targetIndex);
            return true;
        }

        return false;
    }
}