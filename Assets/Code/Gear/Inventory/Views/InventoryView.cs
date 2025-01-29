using UnityEngine;

public class InventoryView : GearView
{
    [SerializeField] private InventoryPresenter inventoryPresenter;
    [SerializeField] private EquipmentPresenter equipmentPresenter;
    [SerializeField] private GameObject itemIcon;
    [SerializeField] private WindowActions windowActions;
    private Transform slot;

    public ItemView AddItem(int index) 
    {
        Transform slots = transform.GetChild(0);
        slot = slots.transform.GetChild(index);
        
        GameObject itemUI = Instantiate(itemIcon, slot);
        ItemView itemView = itemUI.GetComponent<CommonItemView>();
        itemView.Initialize(this, inventoryPresenter, equipmentPresenter, windowActions, index);

        return itemView;
    }
}