using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class GearComponent : MonoBehaviour
{
    [Header("Gear")]
    [SerializeField] protected string gearName;
    [SerializeField] protected int maxSize = 1;
    [SerializeField] protected GearUIComponent uiManager;
    
    protected GearStorage Storage;
    protected IGearManager Manager;
    
    public event Action<Item> OnItemAdded
    {
        add => Manager.OnItemAdded += value;
        remove => Manager.OnItemAdded -= value;
    }
    
    public event Action<Item> OnItemRemoved
    {
        add => Manager.OnItemRemoved += value;
        remove => Manager.OnItemRemoved -= value;
    }
    
    public event Action<Item> OnItemDropped
    {
        add => Manager.OnItemDropped += value;
        remove => Manager.OnItemDropped -= value;
    }
    
    public Item[] GetItems => Storage.Items;
    public int GetSize => maxSize;
    public bool IsFull => Storage.Items.All(item => item.data != null);
    public Item GetItem(int index) => IsValidIndex(index) ? Storage.Items[index] : null;
    private bool IsValidIndex(int index) => index >= 0 && index < Storage.Items.Length;
    
    public event Action<int> OnItemChanged
    {
        add => Manager.OnItemChanged += value;
        remove => Manager.OnItemChanged -= value;
    }

    public virtual void Initialize()
    {
        for (int index = 0; index < Storage.Items.Length; index++) Storage.Items[index] = new Item(); 
        
        uiManager.Initialize(this);
    }
    
    public virtual bool AddItem(Item item, int index)
    {
        if (Manager.AddItem(item, index)) 
        {
            Debug.Log($"Add item in {gearName}: + {item.data.GetName} In slot index: {index}");
            return true;
        }

        Debug.Log($"Fail add item in {gearName} in slot index: {index}");
        return false;
    }

    public virtual void AddItems(List<Item> items)
    {
        foreach (var item in items)
            AddItem(item, 0);
    }

    public virtual void RemoveItem(int index) 
    {
        if (Manager.RemoveItem(index)) 
            Debug.Log($"Item removed from {gearName} at index: {index} ");
        else 
            Debug.Log($"Item not delete from {gearName} at index: {index}");
    }

    public virtual void DropItem(int index)
    {
        if (Manager.DropItem(index)) 
            Debug.Log($"Item dropped from {gearName} at index: {index} ");
        else 
            Debug.Log($"Item not dropped from {gearName} at index: {index}");
    }

    public virtual bool MoveItems(int fromIndex, int targetIndex)
    {
        return Manager.MoveItems(fromIndex, targetIndex);
    }
    
    public virtual bool ContainsItem(Item item, out int existingIndex) { existingIndex = -1; return false; }
}