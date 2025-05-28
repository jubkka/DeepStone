using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    private DefenceComponent defenceComponent;
    private IndicatorComponent indicatorComponent;
    
    private EffectComponent effectComponent;

    public void Init(DefenceComponent defence, IndicatorComponent indicator)
    {
        defenceComponent = defence;
        indicatorComponent = indicator;
    }

    public void TakeDamage(float physicalDamage = 0f, float magicalDamage = 0f)
    {
        float physicalValue = physicalDamage * (100f / (100f + defenceComponent.PhysicalDef));
        float magicalValue = magicalDamage * (100f / (100f + defenceComponent.MagicalDef));
        
        float totalDamage = physicalValue + magicalValue;

        indicatorComponent.Hit(totalDamage);
    }
}
