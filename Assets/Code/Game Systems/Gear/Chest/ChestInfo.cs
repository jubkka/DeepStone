public class ChestInfo : GearInfo
{
    protected override void Initialize()
    {
        component = GearSystems.Instance.GetChestComponent;
    }
}