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
    protected string gearName;
    protected virtual void Initialize() 
    {
        for (int index = 0; index < storage.Items.Length; index++) storage.Items[index] = new Item(); 

        manager.OnItemChanged += NotifyItemChanged;

        uiManager.Initialize();
    }
    protected abstract void Singleton();
    public virtual bool AddItem(Item item, int index) 
    {   
        if (manager.AddItem(item, index)) 
        {
            Debug.Log($"Add item in {gearName}: + {item.data.GetName} In slot index: {index}");
            return true;
        }

        Debug.Log($"Fail add item in {gearName}: {item.data.GetName} in slot index: {index}");
        return false;
    }
    public virtual void RemoveItem(int index) 
    {
        if (manager.RemoveItem(index)) 
            Debug.Log($"Item delete from {gearName}");
        else 
            Debug.Log($"Item not delete from {gearName}");
    }
    public virtual void DropItem(int index) {}
    public abstract bool MoveItems(int fromIndex, int targetIndex); 
    public void NotifyItemChanged(int index) => OnItemChanged?.Invoke(index);
    public bool IsFull() => storage.Items.All(item => item.data != null);
    public Item GetItem(int index) => IsValidIndex(index) ? storage.Items[index] : null;
    public bool IsValidIndex(int index) => index >= 0 && index < storage.Items.Length;
    public virtual bool ContainsItem(Item item, out int existingIndex) { existingIndex = -1; return false; }
}