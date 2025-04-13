public class InventoryInfo : GearInfo 
{
    protected override void Initialize()
    {
        component = GameSystems.Instance.GetInventoryComponent;
    }
}