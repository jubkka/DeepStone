using UnityEngine;

public class HotbarComponent : GearComponent
{
    public InventoryComponent inventory;

    private void Awake() => Initialize();
    protected override void Initialize()
    {
        storage = new GearStorage(maxSize);
        manager = new HotbarManager(storage);
        uiManager = GetComponent<GearUIComponent>();

        inventory.OnItemRemoved += HandleItemRemoved;

        base.Initialize();
    }
    public override bool AddItem(Item item, int index)
    {
        if (manager.AddItem(item, index)) 
        {
            Debug.Log("Add item in hotbar: " + item.data.GetName + " In slot index: " + index);
            return true;
        }

        Debug.Log("Fail add item in equipment: " + item.data.GetName + " In slot index: " + index);
        return false;
    }
    public override void RemoveItem(int index)
    {
        if (manager.RemoveItem(index)) Debug.Log("Item delete from hotbar");
        else Debug.Log("Item not delete from hotbar");
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