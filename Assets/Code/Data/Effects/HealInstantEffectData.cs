using UnityEngine;

[CreateAssetMenu(fileName = "HealInstantEffectData", menuName = "EffectData/HealInstantData")]
public class HealInstantEffectData : InstantEffect
{
    [SerializeField] private int healAmount;
    [SerializeField] private string healColor = "#00000";

    public override string GetDescription()
    {
        return $"<color={healColor}>Heal {healAmount}";
    }


    public override void Apply(EffectComponent component)
    {
        component.Indicator.Heal(healAmount);
    }
}