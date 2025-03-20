public class ChestInfo : GearInfo
{
    protected override void Initialize()
    {
        component = ChestComponent.Instance;
    }
}