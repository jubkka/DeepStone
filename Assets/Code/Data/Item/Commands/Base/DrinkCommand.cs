public class DrinkCommand : IItemCommand
{
    private EffectComponent effectComponent;

    public DrinkCommand(EffectComponent effectComponent)
    {
        this.effectComponent = effectComponent;
    }

    public void Execute(Item item)
    {
        if (item.data is PotionData potionData)
            potionData.Drink(effectComponent);

        item.Amount -= 1;
    }
}