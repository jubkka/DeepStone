public class SpellInfo : GearInfo
{
    protected override void Initialize()
    {
        component = GearSystems.Instance.Spell;
    }
}