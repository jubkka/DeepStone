public class SpellComponent : GearComponent
{
    private SpellManager spellManager;
    
    public override void Initialize()
    {
        Storage = new GearStorage(maxSize);
        spellManager = new SpellManager(Storage);
        Manager = spellManager;
        
        base.Initialize();
    }

    public override void DropItem(int index) {}

    public override bool MoveItems(int fromIndex, int targetIndex)
    {
        return Manager.MoveItems(fromIndex, targetIndex);
    }
}