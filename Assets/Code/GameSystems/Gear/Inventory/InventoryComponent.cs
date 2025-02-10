using System;
using UnityEngine;

public class InventoryComponent : GearComponent 
{
    public event Action<Item> OnItemRemoved;

    protected void Awake() => Initialize();

    protected override void Initialize()
    {
        storage = new InventoryStorage(maxSize);
        manager = new InventoryManager(storage);
        uiManager = GetComponent<InventoryUIManager>();

        base.Initialize();
    }

    public override void AddItem(Item item, int index = 0) 
    { 
        if (manager.AddItem(item, index)) 
        {
            Debug.Log("Add item in inventory: " + item.data.GetName);
        }
    }
    public override void RemoveItem(int index)
    {
        Item removedItem = storage.Items[index];

        if (manager.RemoveItem(index)) 
        {
            Debug.Log("Item delete from inventory");
            OnItemRemoved?.Invoke(removedItem);
        }
        else Debug.Log("Item not delete from inventory");
    }

    public override bool MoveItems(int fromIndex, int targetIndex) 
    {
        if (manager.MoveItems(fromIndex, targetIndex)) return true;
        return false;
    }

}