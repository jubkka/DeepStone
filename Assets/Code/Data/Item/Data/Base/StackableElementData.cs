using UnityEngine;

public abstract class StackableElementData : ElementData
{
    [SerializeField] private int maxStackSize;
    public int GetMaxStackSize => maxStackSize;
}