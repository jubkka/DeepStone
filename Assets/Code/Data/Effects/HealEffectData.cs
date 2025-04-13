using UnityEngine;

[CreateAssetMenu(fileName = "HealEffectData", menuName = "HealEffectData", order = 0)]
public class HealEffectData : ItemEffectData
{
    [SerializeField] private int healAmount;

    public override void Apply(EffectComponent component)
    {
        component.Heal(healAmount);
    }
}