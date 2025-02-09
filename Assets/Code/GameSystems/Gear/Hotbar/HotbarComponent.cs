using UnityEngine;

public class HotbarComponent : GearComponent
{
    private void Awake() => Initialize();

    protected override void Initialize()
    {
        storage = new HotbarStorage(maxSize);
        manager = new HotbarManager(storage);
        uiManager = GetComponent<GearUIComponent>();

        base.Initialize();
    }

    public override void AddItem(Item item, int index)
    {
        if (manager.AddItem(item, index)) 
        {
            Debug.Log("Add item in hotbar: " + item.data.GetName + " In slot index: " + index);
        }
    }
    public override void RemoveItem(int index)
    {
        if (manager.RemoveItem(index)) Debug.Log("Item delete from hotbar");
        else Debug.Log("Item not delete from hotbar");
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