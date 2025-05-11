using System;

public abstract class GearManager
{
    protected GearStorage Storage;
    public event Action<int> OnItemChanged;

    protected GearManager(GearStorage storage) 
    {
        this.Storage = storage;
    }

    protected void InvokeItemChanged(int index) => OnItemChanged?.Invoke(index);
    public abstract bool AddItem(Item item, int index);
    public abstract bool RemoveItem(int index);
    public abstract bool MoveItems(int fromIndex, int targetIndex);
}