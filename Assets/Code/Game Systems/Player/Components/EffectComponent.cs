public class EffectComponent
{
    private IndicatorComponent indicator;
    
    private ItemEffectData[] itemEffectData;

    public EffectComponent(Origin origin, IndicatorComponent indicatorComponent)
    {
        indicator = indicatorComponent;
    }

    public EffectComponent(IndicatorComponent indicatorComponent) //Save TODO
    {
        indicator = indicatorComponent;
    }

    public void GetDefenceEffects()
    {
        /*foreach (var effect in itemEffectData)
        {
            if (effect is DefenceEffectData)
            {
                
            }
        } */  
    }

    public void Heal(int healAmount) 
    {
        indicator.Heal(healAmount);
    }

    private void Timer()
    {
        
    }
}
