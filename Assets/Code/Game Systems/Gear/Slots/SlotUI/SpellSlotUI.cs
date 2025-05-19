public class SpellSlotUI : TooltipSlotUI
{
    protected override void Initialization()
    {
        gear = GearSystems.Instance.Spell; 
    }
}