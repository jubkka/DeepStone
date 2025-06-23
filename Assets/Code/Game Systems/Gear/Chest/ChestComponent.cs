public class ChestComponent : GearComponent
{
    private ChestManager chestManager;
    
    public override void Initialize() 
    {
        Storage = new GearStorage(maxSize);
        chestManager = new ChestManager(Storage);
        Manager = chestManager;

        base.Initialize();
    }
    
    public Item[] TakeItems() 
    {
        return chestManager.TakeItems();
    }
    
    public override bool MoveItems(int fromIndex, int targetIndex)
    {
        return Manager.MoveItems(fromIndex, targetIndex);
    }

    public override void DropItem(int index) { }
}