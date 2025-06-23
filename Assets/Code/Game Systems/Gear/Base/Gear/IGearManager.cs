using System;

public interface IGearManager
{
    public bool AddItem(Item item, int index);
    public bool RemoveItem(int index);
    public bool DropItem(int index);
    public bool MoveItems(int fromIndex, int targetIndex);
    
    public event Action<int> OnItemChanged;
    public event Action<Item> OnItemAdded;
    public event Action<Item> OnItemRemoved;
    public event Action<Item> OnItemDropped;
}
