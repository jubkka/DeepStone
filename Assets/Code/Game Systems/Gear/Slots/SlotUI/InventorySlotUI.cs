public class InventorySlotUI : TooltipSlotUI
{
    protected override void Initialization()
    {
        gear = GearSystems.Instance.GetInventoryComponent;
    }
}