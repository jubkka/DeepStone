public class TakeCommand : IItemCommand
{
    private HandComponent handComponent;
    
    public TakeCommand(HandComponent handComponent)
    {
        this.handComponent = handComponent;
    }
    
    public void Execute(Item item)
    {
        handComponent.PutInHand(item);    
    }
}