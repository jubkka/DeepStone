using System;
using UnityEngine;

public abstract class GearComponent : MonoBehaviour 
{
    public int maxSize = 1;
    public event Action<int> OnItemChanged;
    [SerializeField] protected GearStorage storage;
    protected GearManager manager;
    protected GearUIComponent uiManager;
    
    protected virtual void Initialize() 
    {
        for (int index = 0; index < storage.Items.Length; index++) storage.Items[index] = new Item(); 

        manager.OnItemChanged += NotifyItemChanged;

        uiManager.Initialize();
    }

    public abstract void AddItem(Item item, int index); 
    public abstract void RemoveItem(int index);
    public abstract bool MoveItems(int fromIndex, int targetIndex); 
    public void NotifyItemChanged(int index) => OnItemChanged?.Invoke(index);
    public Item GetItem(int index) => IsValidIndex(index) ? storage.Items[index] : null;
    public bool IsValidIndex(int index) => index >= 0 && index < storage.Items.Length;

    public virtual bool ContainsItem(Item item, out int existingIndex) { existingIndex = -1; return false; }

}