public class InventorySlotUI : TooltipSlotUI
{
    protected override void Initialization()
    {
        gear = GameSystems.Instance.GetInventoryComponent;
    }
}