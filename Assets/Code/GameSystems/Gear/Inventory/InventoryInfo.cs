public class InventoryInfo : GearInfo 
{
    protected override void Initialize()
    {
        component = InventoryComponent.Instance;
    }
}