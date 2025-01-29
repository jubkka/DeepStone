using UnityEngine;

public abstract class ItemModel
{
    public ItemData data;
    public ItemView itemView;
    public int count;
    public ItemModel(ItemData data) : this(data, 1) {}
    public ItemModel(ItemData data,  int count) : this(data, null, count) {}
    public ItemModel(ItemData data, ItemView itemView, int count) 
    {
        this.data = data;
        this.itemView = itemView;
        this.count = count;
    }

    public abstract ItemModel PickUp(InventoryModel inventory, ref int index);
    internal void Drop(InventoryPresenter inventoryPresenter) 
    {
        inventoryPresenter.RemoveItem(itemView.GetIndex);
    }
    public virtual void Use(InventoryPresenter inventoryPresenter, EquipmentPresenter equipmentPresenter) 
    {
        Debug.Log("Use item");
    }
}
