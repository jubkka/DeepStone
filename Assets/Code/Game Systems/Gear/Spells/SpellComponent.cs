public class SpellComponent : GearComponent
{
    public override void Initialize()
    {
        Storage = new GearStorage(maxSize);
        Manager = new SpellManager(Storage);
        
        base.Initialize();
    }

    public override bool AddItem(Item item, int index)
    {
        return false;
    }

    public override bool MoveItems(int fromIndex, int targetIndex)
    {
        throw new System.NotImplementedException();
    }
}