using UnityEngine;

public abstract class ItemView : MonoBehaviour 
{   
    protected InventoryView inventoryView;
    protected InventoryPresenter inventoryPresenter;
    protected EquipmentPresenter equipmentPresenter;
    protected WindowActions windowActions;
    protected int index;
    public ItemModel itemModel;
    public int GetIndex { get => index; }
    
    public void Initialize(InventoryView inventoryView, InventoryPresenter inventoryPresenter, EquipmentPresenter equipmentPresenter,WindowActions windowActions,int index) 
    {
        this.inventoryView = inventoryView;
        this.inventoryPresenter = inventoryPresenter;
        this.equipmentPresenter = equipmentPresenter;
        this.windowActions = windowActions;
        this.index = index;
    }

    public abstract void Refresh();
    public abstract void Use(); 
    public abstract void Drop(); 
}