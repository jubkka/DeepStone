public class EquipmentInfo : GearInfo
{
    protected override void Initialize()
    {
        component = GameSystems.Instance.GetEquipmentComponent;
    }
}