using System;
using UnityEngine;

[Serializable]
public class Item 
{
    public ItemData data;
    [SerializeField] private int amount;
    [SerializeField] private string uniqueId;
    public string GetUniqueId => uniqueId;
    public bool IsEmpty { get => data == null; }

    public int Amount 
    {
        get
        {
            return amount;
        } 
        set
        { 
            amount = value;
            onChanged?.Invoke();
        }
    }

    public delegate void OnChanged();
    public event OnChanged onChanged;

    public Item() {}
    public Item(ItemData data, int amount) 
    {
        this.data = data;
        this.amount = amount;
        this.uniqueId = Guid.NewGuid().ToString();
    }
}