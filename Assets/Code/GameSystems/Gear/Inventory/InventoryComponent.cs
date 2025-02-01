using System;
using UnityEngine;

public class InventoryComponent : MonoBehaviour 
{
    private const int MaxInventorySize = 20;
    public ItemSlot[] items = new ItemSlot[MaxInventorySize];
    public event Action<int> onInventoryChanged;
    
    public void AddItem(ItemSlot itemSlot, int stack) 
    {
        for (int i = 0; i < stack; i++) 
        {
            ItemSlot newItemSlot = new ItemSlot(itemSlot.item, itemSlot.amount);

            if (itemSlot.item.IsStackable) StackItem(newItemSlot);
            PlaceItem(newItemSlot);
        }  
    }

    private void StackItem(ItemSlot itemSlot) 
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (itemSlot.amount <= 0) return;

            ItemSlot itemSlotInInv = items[i];
            
            bool match = !itemSlotInInv.IsEmpty &&
                itemSlotInInv.item.GetId == itemSlot.item.GetId &&
                itemSlotInInv.amount < itemSlot.item.GetMaxStackSize;

            if (match) 
            {
                int countToPut = Math.Min(itemSlot.amount, itemSlotInInv.item.GetMaxStackSize - itemSlotInInv.amount); 

                if (countToPut > 0) 
                {
                    itemSlotInInv.amount += countToPut;
                    itemSlot.amount -= countToPut;

                    onInventoryChanged?.Invoke(i);
                }
            }
        }
    }
    
    private void PlaceItem(ItemSlot itemSlot) 
    {
        if (itemSlot.amount <= 0) return;

        int index = Array.FindIndex(items, slot => slot.IsEmpty);
        if (index == -1) 
        {
            Debug.LogWarning("Inventory full!");
            return;
        }

        items[index] = new ItemSlot(itemSlot.item, itemSlot.amount);

        onInventoryChanged?.Invoke(index);
    }

    public void RemoveItem(int index) 
    {
        if (index < 0 || index >= items.Length || items[index].item == null) return;

        items[index].item = null;
        items[index].amount = 0;

        onInventoryChanged?.Invoke(index);
    }
    
    public bool MoveItems(int fromIndex, int targetIndex) 
    {
        if (fromIndex == targetIndex) return false; 

        ItemSlot fromItemSlot = items[fromIndex];
        ItemSlot targetItemSlot = items[targetIndex];

        bool move = false;

        if (targetItemSlot.IsEmpty) 
        {
            ToEmptySlot(fromIndex, targetIndex);
            move = true;
        }
        else if (fromItemSlot.item.GetId == targetItemSlot.item.GetId) 
        {
            MergeItems(fromIndex, targetIndex);
        }
        else 
        {
            SwapItems(fromIndex, targetIndex);
        }

        onInventoryChanged?.Invoke(fromIndex);
        onInventoryChanged?.Invoke(targetIndex);

        return move;
    }

    private void MergeItems(int fromIndex, int targetIndex) 
    {
        int countToPut = Math.Min(items[fromIndex].amount, items[targetIndex].item.GetMaxStackSize - items[targetIndex].amount);

        items[targetIndex].amount += countToPut;
        items[fromIndex].amount -= countToPut;

        if (items[fromIndex].amount <= 0) RemoveItem(fromIndex);
    }

    private void ToEmptySlot(int fromIndex, int targetIndex) 
    {
        items[targetIndex] = new ItemSlot(items[fromIndex].item, items[fromIndex].amount);

        RemoveItem(fromIndex);
    }

    private void SwapItems(int fromIndex, int targetIndex) 
    {
        ItemSlot fromItemSlot = items[fromIndex];
        ItemSlot targetItemSlot = items[targetIndex];

        items[fromIndex] = targetItemSlot;
        items[targetIndex] = fromItemSlot;
    }
}