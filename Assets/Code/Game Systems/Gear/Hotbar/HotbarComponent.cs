using UnityEngine;

public class HotbarComponent : GearComponent
{
    private InventoryComponent inventory;
    private HotbarManager hotbarManager;
    
    public override void Initialize()
    {
        Storage = new GearStorage(maxSize);
        hotbarManager = new HotbarManager(Storage);
        Manager = hotbarManager;

        base.Initialize();
    }

    public void Initialize(InventoryComponent inventoryComponent)
    {
        Initialize();
        
        inventory = inventoryComponent;
        inventory.OnItemRemoved += HandleItemRemoved;
    }

    private void HandleItemRemoved(Item item) 
    {
        hotbarManager.HandleItemRemoved(item);
    }

    public override bool AddItem(Item item, int index) 
    {   
        if (Manager.AddItem(item, index)) 
        {
            Debug.Log($"Add item in {gearName}: + {item.data.GetName} at slot index: {index}");
            item.OnItemCountZero += HandleItemRemoved;
            return true;
        }

        Debug.Log($"Fail add item in {gearName}: {item.data.GetName} at slot index: {index}");
        return false;
    }

    public override bool MoveItems(int fromIndex, int targetIndex)
    {
        return Manager.MoveItems(fromIndex, targetIndex);
    }

    public override bool ContainsItem(Item item, out int existingIndex) 
    {
        return hotbarManager.ContainsItem(item, out existingIndex);
    }
}