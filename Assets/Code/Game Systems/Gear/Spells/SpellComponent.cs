public class SpellComponent : GearComponent
{
    public override void Initialize()
    {
        Storage = new GearStorage(maxSize);
        Manager = new SpellManager(Storage);
        
        base.Initialize();
    }

    public override void DropItem(int index) {}

    public override bool MoveItems(int fromIndex, int targetIndex)
    {
        return Manager.MoveItems(fromIndex, targetIndex);
    }
}