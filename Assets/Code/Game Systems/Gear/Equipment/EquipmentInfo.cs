public class EquipmentInfo : GearInfo
{
    protected override void Initialize()
    {
        component = GearSystems.Instance.Equipment;
    }
}