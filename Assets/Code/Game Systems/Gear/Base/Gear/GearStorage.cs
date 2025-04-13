using System;
using UnityEngine;

[Serializable]
public class GearStorage
{
    [SerializeField] protected Item[] items;   
    public Item[] Items => items;
    public GearStorage(int size) => items = new Item[size];

    public void SetItem(Item item, int index) 
    {
        if (index < 0 || index >= Items.Length) return;
        
        Items[index] = item;
    }

    public Item GetItem(int index)
    {
        if (index < 0 || index >= Items.Length) return null;
        
        return items[index];
    }
}