using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PoisonTemporaryEffectData", menuName = "EffectData/PoisonTemporaryEffectData")]
public class PoisonTemporaryEffect : TemporaryEffect
{
    [SerializeField] private int poisonDamage;
    [SerializeField] private string poisonColor = "#FFF1FF";
    
    public int PoisonDamage => poisonDamage;

    public override string GetDescription()
    {
        return $"Poison Damage: <color={poisonColor}>{poisonDamage}";
    }

    public override void Apply(EffectComponent effectComponent)
    {
        Action action = 
            () => effectComponent.Damage.TakeDamageByEffect(poisonDamage);
        
        effectComponent.RegisterTemporaryEffect(this, action);
    }
}