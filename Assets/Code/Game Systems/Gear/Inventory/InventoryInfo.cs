using UnityEngine;

public class InventoryInfo : GearInfo 
{
    [SerializeField] InventoryComponent inventoryComponent;
    
    protected override void Initialize()
    {
        component = GearSystems.Instance.Inventory;
    }
}