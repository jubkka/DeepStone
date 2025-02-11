using UnityEngine;

public class EquipmentComponent : GearComponent
{
    private void Awake() => Initialize();

    protected override void Initialize()
    {
        storage = new GearStorage(maxSize);
        manager = new EquipmentManager(storage);
        uiManager = GetComponent<GearUIComponent>();

        base.Initialize();
    }

    public override void AddItem(Item item, int index)
    {
        if (manager.AddItem(item, index)) 
        {
            Debug.Log("Add item in equipment: " + item.data.GetName + " In slot index: " + index);
        }
    }
    public override void RemoveItem(int index)
    {
        if (manager.RemoveItem(index)) 
        {
            Debug.Log("Remove item from equipment slot index: " + index);
        }
    }

    public override bool MoveItems(int fromIndex, int targetIndex)
    {
        return false;
    }

}