using System;

public abstract class GearManager
{
    protected GearStorage storage;
    public event Action<int> OnItemAdded;

    public GearManager(GearStorage storage) 
    {
        this.storage = storage;
    }

    protected void InvokeItemAdded(int index) => OnItemAdded?.Invoke(index);
    public abstract bool AddItem(Item item, int index);
    public abstract bool RemoveItem(int index);
    public abstract bool MoveItems(int fromIndex, int targetIndex);

}