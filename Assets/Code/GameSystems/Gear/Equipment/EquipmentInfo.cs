public class EquipmentInfo : GearInfo
{
    protected override void Initialize()
    {
        component = EquipmentComponent.Instance;
    }
}