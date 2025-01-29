using UnityEngine;

public class InventoryPresenter : GearPresenter 
{
    [SerializeField] private InventoryModel inventoryModel;
    int index = -1;

    public void AddItem(ItemModel pickItem) 
    {   
        ItemModel item = pickItem.PickUp(inventoryModel, ref index);

        if (item == null) return;

        inventoryModel.items[index] = item;
    }

    public void RemoveItem(int index) 
    {
        inventoryModel.items[index] = null;
    }
}