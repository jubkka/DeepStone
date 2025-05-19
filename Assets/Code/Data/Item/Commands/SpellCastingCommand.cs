public class SpellCastingCommand : IItemCommand
{
    private SpellCastingComponent spellCastingComponent;

    public SpellCastingCommand(SpellCastingComponent spellCastingComponent)
    {
        this.spellCastingComponent = spellCastingComponent;
    }

    public void Execute(Item item)
    {
        spellCastingComponent.Cast();
    }
}