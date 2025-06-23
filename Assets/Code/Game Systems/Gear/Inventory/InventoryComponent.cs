using System;

public class InventoryComponent : GearComponent
{
    private InventoryManager inventoryManager;
    
    public event Action<Item> OnItemCountZero
    {
        add => inventoryManager.OnItemCountZero += value;
        remove => inventoryManager.OnItemCountZero -= value;
    }

    public override void Initialize()
    {
        Storage = new GearStorage(maxSize);
        inventoryManager = new InventoryManager(Storage);
        Manager = inventoryManager;

        base.Initialize();
    }
}