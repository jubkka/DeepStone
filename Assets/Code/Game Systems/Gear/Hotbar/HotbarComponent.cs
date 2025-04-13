using System;
using UnityEngine;

public class HotbarComponent : GearComponent
{
    private InventoryComponent inventory;
    private HandComponent hand;

    protected override void Initialize()
    {
        Storage = new GearStorage(maxSize);
        Manager = new HotbarManager(Storage);

        base.Initialize();
    }

    protected override void PostInitialize() 
    {
        base.PostInitialize();

        inventory = GameSystems.Instance.GetInventoryComponent;
        inventory.OnItemRemoved += HandleItemRemoved;
    }

    private void HandleItemRemoved(Item item) 
    {
        for (int i = 0; i < Storage.Items.Length; i++)
        {
            if (Storage.Items[i] == item) RemoveItem(i);
        }
    }

    public override bool AddItem(Item item, int index) 
    {   
        if (Manager.AddItem(item, index)) 
        {
            Debug.Log($"Add item in {gearName}: + {item.data.GetName} In slot index: {index}");
            item.OnItemCountZero += HandleItemRemoved;
            return true;
        }

        Debug.Log($"Fail add item in {gearName}: {item.data.GetName} in slot index: {index}");
        return false;
    }

    public override void DropItem(int index)
    {
        RemoveItem(index);
    }

    public override bool MoveItems(int fromIndex, int targetIndex)
    {
        return Manager.MoveItems(fromIndex, targetIndex);
    }

    public override bool ContainsItem(Item item, out int existingIndex) 
    {
        for (int i = 0; i < Storage.Items.Length; i++)
        {
            if (Storage.Items[i] != null && Storage.Items[i].GetUniqueId == item.GetUniqueId) 
            {
                existingIndex = i;

                return true;
            }
        }

        existingIndex = -1;

        return false;
    }

}