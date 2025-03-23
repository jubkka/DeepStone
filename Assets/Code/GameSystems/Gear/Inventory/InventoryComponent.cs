using System;
using UnityEngine;

public class InventoryComponent : GearComponent 
{
    [SerializeField] private DropManager dropManager;
    public static InventoryComponent Instance;
    public event Action<Item> OnItemRemoved;

    protected void Awake() => Initialize();
    protected override void Initialize()
    {
        Singleton();
        
        storage = new GearStorage(maxSize);
        manager = new InventoryManager(storage);
        uiManager = GetComponent<GearUIComponent>();

        gearName = "Inventory";

        base.Initialize();
    }
    protected override void Singleton() 
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);  
    }
    public override void DropItem(int index) 
    {
        dropManager.Drop(storage.GetItem(index));
        RemoveItem(index);
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
    public override bool MoveItems(int fromIndex, int targetIndex)
    {
        if (manager.MoveItems(fromIndex, targetIndex)) return true;
        return false;
    }
}