using System;
using UnityEngine.AI;

public class StackItemsCommand : IMoveCommand
{
    private int fromIndex;
    private int targetIndex;

    public StackItemsCommand(int fromIndex, int targetIndex) 
    {
        this.fromIndex = fromIndex;
        this.targetIndex = targetIndex;
    }
    public bool Execute(Item[] items)
    {
        if (items[fromIndex].IsEmpty || items[targetIndex].IsEmpty) return false;

        if (items[fromIndex].data.GetId == items[targetIndex].data.GetId) 
        {
            int maxStackSize = items[targetIndex].GetMaxStackSize;

            int amountToMove = Math.Min(items[fromIndex].Amount, maxStackSize - items[targetIndex].Amount);

            if (amountToMove > 0) 
            {
                items[targetIndex].Amount += amountToMove;
                items[fromIndex].Amount -= amountToMove;

                if (items[fromIndex].Amount <= 0)
                    items[fromIndex] = new Item();
                return true;
            }
        }
        
        return false;
    }
}