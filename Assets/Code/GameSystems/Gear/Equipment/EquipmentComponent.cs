using UnityEngine;

public class EquipmentComponent : GearComponent
{
    public static EquipmentComponent Instance;
    protected void Awake() => Initialize();
    private void Singleton() 
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);  
    }

    protected override void Initialize()
    {
        Singleton();
        
        storage = new GearStorage(maxSize);
        manager = new EquipmentManager(storage);
        uiManager = GetComponent<GearUIComponent>();

        base.Initialize();
    }

    public override bool AddItem(Item item, int index)
    {
        if (manager.AddItem(item, index)) 
        {
            Debug.Log("Add item in equipment: " + item.data.GetName + " In slot index: " + index);
            return true;
        }
        Debug.Log("Fail add item in equipment: " + item.data.GetName + " In slot index: " + index);
        return false;
    }
    public override void RemoveItem(int index)
    {
        if (manager.RemoveItem(index)) 
            Debug.Log("Remove item from equipment slot index: " + index);
        else 
            Debug.Log("Item not remove from equipment slot index: " + index);
    }

    public override bool MoveItems(int fromIndex, int targetIndex)
    {
        return false;
    }

}