public class ChestSlotUI : TooltipSlotUI
{
    protected override void Initialization()
    {
        gear = GameSystems.Instance.GetChestComponent;
    }
}