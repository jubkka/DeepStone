public class InventoryInfo : GearInfo 
{
    protected override void Initialize()
    {
        component = GearSystems.Instance.Inventory;
    }
}