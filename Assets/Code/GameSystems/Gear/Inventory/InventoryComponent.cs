using System;
using UnityEngine;

public class InventoryComponent : GearComponent 
{
    public event Action<Item> OnItemRemoved;

    protected void Awake() => Initialize();

    protected override void Initialize()
    {
        storage = new GearStorage(maxSize);
        manager = new InventoryManager(storage);
        uiManager = GetComponent<GearUIComponent>();

        base.Initialize();
    }

    public override void AddItem(Item item, int index = -1) 
    { 
        if (manager.AddItem(item, index)) 
        {
            Debug.Log($"Add item in inventory: {item.data.GetName} in slot by index {index}" );
        }
        else 
        {
            Debug.Log($"Fail add item in inventory: {item.data.GetName} in slot by index {index}");
        }
    }
    public override void RemoveItem(int index)
    {
        Item removedItem = storage.Items[index];

        if (manager.RemoveItem(index)) 
        {
            Debug.Log($"Item delete from inventory from index {index}");
            OnItemRemoved?.Invoke(removedItem);
        }
        else
        {
            Debug.Log($"Item not delete from inventory by index {index}");
        }
    }

    public override bool MoveItems(int fromIndex, int targetIndex) // убрать bool
    {
        if (manager.MoveItems(fromIndex, targetIndex)) return true;
        return false;
    }

}