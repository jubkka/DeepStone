public class ChestSlotUI : TooltipSlotUI
{
    protected override void Initialization()
    {
        gear = GearSystems.Instance.Chest;
    }
}