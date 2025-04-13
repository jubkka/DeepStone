using System;

public abstract class GearManager
{
    protected GearStorage storage;
    public event Action<int> OnItemChanged;

    public GearManager(GearStorage storage) 
    {
        this.storage = storage;
    }

    protected void InvokeItemChanged(int index) => OnItemChanged?.Invoke(index);
    public abstract bool AddItem(Item item, int index);
    public abstract bool RemoveItem(int index);
    public abstract bool MoveItems(int fromIndex, int targetIndex);
}