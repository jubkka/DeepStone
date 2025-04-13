public class SwapItemsCommand : IMoveCommand
{
    private int fromIndex;
    private int targetIndex;

    public SwapItemsCommand(int fromIndex, int targetIndex)
    {
        this.fromIndex = fromIndex;
        this.targetIndex = targetIndex;
    }

    public bool Execute(Item[] items)
    {
        if (items[fromIndex].IsEmpty || items[targetIndex].IsEmpty) return false;

        (items[fromIndex], items[targetIndex]) = (items[targetIndex], items[fromIndex]);

        return true;
    }
}