public class AttackCommand : IItemCommand
{
    private AttackComponent attackComponent;

    public AttackCommand(AttackComponent attackComponent)
    {
        this.attackComponent = attackComponent;
    }

    public void Execute(Item item)
    {
        attackComponent.Attack();
    }
}