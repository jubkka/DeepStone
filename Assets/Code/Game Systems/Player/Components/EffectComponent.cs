public class EffectComponent
{
    private IndicatorComponent indicator;

    public EffectComponent(Origin origin, IndicatorComponent indicatorComponent)
    {
        indicator = indicatorComponent;
    }

    public EffectComponent(IndicatorComponent indicatorComponent) //Save
    {
        indicator = indicatorComponent;
    }

    public void Heal(int healAmount) 
    {
        indicator.Heal(healAmount);
    }
}
