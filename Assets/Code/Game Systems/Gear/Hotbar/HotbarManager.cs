using System;

public class HotbarManager : IGearManager
{
    private GearStorage storage;
    
    public event Action<int> OnItemChanged;
    public event Action<Item> OnItemAdded;
    public event Action<Item> OnItemRemoved;
    public event Action<Item> OnItemDropped;

    public HotbarManager(GearStorage storage)
    {
        this.storage = storage;
    }

    public bool AddItem(Item item, int index)
    {
        if (item == null)
            return false;
        
        storage.SetItem(item, index);
        OnItemAdded?.Invoke(item);
        OnItemChanged?.Invoke(index);
        
        return true;
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
        return false;
    }
    
    public bool MoveItems(int fromIndex, int targetIndex)
    {
        if (fromIndex == targetIndex) 
            return false;

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
            OnItemChanged?.Invoke(fromIndex);
            OnItemChanged?.Invoke(targetIndex);
            return true;
        }

        return false;
    }
    
    public void HandleItemRemoved(Item item) 
    {
        for (int i = 0; i < storage.Items.Length; i++)
        {
            if (storage.Items[i] == item) 
                RemoveItem(i);
        }
    }
    
    public bool ContainsItem(Item item, out int existingIndex) 
    {
        for (int i = 0; i < storage.Items.Length; i++)
        {
            if (storage.Items[i] != null && storage.Items[i].GetUniqueId == item.GetUniqueId) 
            {
                existingIndex = i;

                return true;
            }
        }

        existingIndex = -1;

        return false;
    }
}