using System;
using System.Linq;
using UnityEngine;

public abstract class GearComponent : MonoBehaviour 
{
    public int maxSize = 1;
    public event Action<int> OnItemChanged;
    protected GearStorage storage;
    protected GearManager manager;
    protected GearUIComponent uiManager;
    public GearStorage GetStorage => storage;

    protected virtual void Initialize() 
    {
        for (int index = 0; index < storage.Items.Length; index++) storage.Items[index] = new Item(); 

        manager.OnItemChanged += NotifyItemChanged;

        uiManager.Initialize();
    }

    public abstract bool AddItem(Item item, int index); 
    public abstract void RemoveItem(int index);
    public abstract bool MoveItems(int fromIndex, int targetIndex); 
    public void NotifyItemChanged(int index) => OnItemChanged?.Invoke(index);

    public bool IsFull() => storage.Items.Any(item => item.data != null);
    public Item GetItem(int index) => IsValidIndex(index) ? storage.Items[index] : null;
    public bool IsValidIndex(int index) => index >= 0 && index < storage.Items.Length;
    public virtual bool ContainsItem(Item item, out int existingIndex) { existingIndex = -1; return false; }
}