using System;
using UnityEngine;

public class InventoryComponent : GearComponent
{
    public event Action<Item> OnItemAdded;
    public event Action<Item> OnItemRemoved;
    
    public override void Initialize()
    {
        Storage = new GearStorage(maxSize);
        Manager = new InventoryManager(Storage);

        base.Initialize();
    }
    
    public override void DropItem(int index) 
    {
        OnItemRemoved?.Invoke(GetItem(index));
        RemoveItem(index);
    }

    public override bool AddItem(Item item, int index) 
    {   
        if (Manager.AddItem(item, index)) 
        {
            Debug.Log($"Add item in {gearName}: + {item.data.GetName} In slot index: {index}");
            OnItemAdded?.Invoke(item);
            return true;
        }

        Debug.Log($"Fail add item in {gearName}: {item.data.GetName} in slot index: {index}");
        return false;
    }
    
    public override bool MoveItems(int fromIndex, int targetIndex)
    {
        return Manager.MoveItems(fromIndex, targetIndex);
    }
}