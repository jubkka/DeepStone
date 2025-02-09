public class MoveToEmptySlotCommand : IMoveCommand
{
    private int fromIndex;
    private int targetIndex;

    public MoveToEmptySlotCommand(int fromIndex, int targetIndex)
    {
        this.fromIndex = fromIndex;
        this.targetIndex = targetIndex;
    }

    public bool Execute(Item[] items)
    {
        if (items[fromIndex].IsEmpty && !items[targetIndex].IsEmpty) return false;

        items[targetIndex] = items[fromIndex];
        items[fromIndex] = new Item();

        return true;
    }
}