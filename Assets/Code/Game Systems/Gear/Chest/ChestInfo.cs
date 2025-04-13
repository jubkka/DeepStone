public class ChestInfo : GearInfo
{
    protected override void Initialize()
    {
        component = GameSystems.Instance.GetChestComponent;
    }
}