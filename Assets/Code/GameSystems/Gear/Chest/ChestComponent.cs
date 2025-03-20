using System;
using UnityEngine;

public class ChestComponent : GearComponent {
    [SerializeField] private InventoryComponent inventoryComponent;
    static public ChestComponent Instance;
    public event Action<Item> OnItemRemoved;

    protected void Awake() => Initialize();
    protected override void Initialize() 
    {
        Singleton();

        storage = new GearStorage(maxSize);
        manager = new ChestManager(storage);
        uiManager = GetComponent<GearUIComponent>();

        base.Initialize();
    }

    private void Singleton()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);   
    }

    public override bool AddItem(Item item, int index = -1)
    {
        if (manager.AddItem(item, index)) 
        {
            Debug.Log($"Add item in chest: {item.data.GetName} in slot by index {index}" );
            return true;
        }
        Debug.Log($"Fail add item in chest: in slot by index {index}");
        return false;
    }
    public override void RemoveItem(int index)
    {
        Item removedItem = storage.Items[index];

        if (manager.RemoveItem(index)) 
        {
            Debug.Log($"Item delete from chest from index {index}");
            OnItemRemoved?.Invoke(removedItem);
        }
        else
            Debug.Log($"Item not delete from chest by index {index}");
    }

    public override bool MoveItems(int fromIndex, int targetIndex)
    {
        if (manager.MoveItems(fromIndex, targetIndex)) return true;
        return false;
    }

}