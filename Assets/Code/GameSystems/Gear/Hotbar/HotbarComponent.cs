using System;
using UnityEngine;

public class HotbarComponent : GearComponent
{
    [SerializeField] private HotbarGameObjects hotbarGameObjects;
    private InventoryComponent inventory;
    static public HotbarComponent Instance;
    private void Awake() => Initialize();
    protected override void Singleton() 
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);  
    }
    protected override void Initialize()
    {
        Singleton();

        inventory = InventoryComponent.Instance;
        
        storage = new GearStorage(maxSize);
        manager = new HotbarManager(storage);
        uiManager = GetComponent<GearUIComponent>();

        gearName = "Hotbar";

        inventory.OnItemRemoved += HandleItemRemoved;

        base.Initialize();
    }
    private void HandleItemRemoved(Item item) 
    {
        for (int i = 0; i < storage.Items.Length; i++)
        {
            if (storage.Items[i] == item) RemoveItem(i);
        }
    }
    public override bool MoveItems(int fromIndex, int targetIndex)
    {
        return manager.MoveItems(fromIndex, targetIndex);
    }
    public override bool ContainsItem(Item item, out int existingIndex) 
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