using System;
using UnityEngine;

[Serializable]
public class GearStorage
{
    [SerializeField] protected Item[] items;   
    public Item[] Items => items;
    public GearStorage(int size) => items = new Item[size];
    public event Action<int> OnItemChanged;

    public void SetItem(Item item, int index) 
    {
        if (index < 0 || index >= Items.Length) return;
        
        Items[index] = item;
        InvokeItemChanged(index);
    }

    public void InvokeItemChanged(int index) => OnItemChanged?.Invoke(index);
}