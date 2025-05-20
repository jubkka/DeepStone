using UnityEngine;

public abstract class StackableItemData : ItemData
{
    [SerializeField] private int maxStackSize;
    public int GetMaxStackSize => maxStackSize;
}