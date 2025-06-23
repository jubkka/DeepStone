using System;
using UnityEngine;

[CreateAssetMenu(fileName = "HealTemporaryData", menuName = "EffectData/HealTemporaryData")]
public class HealTemporaryEffectData : TemporaryEffect
{
    [SerializeField] private int healAmount;
    [SerializeField] private string healColor = "#FF4444";
    
    public int HealAmount => healAmount;

    public override string GetDescription()
    {
        return $"Heal <color={healColor}>{healAmount}</color>";
    }

    public override void Apply(EffectComponent effectComponent)
    {
        Action action = () => effectComponent.Indicator.Heal(healAmount);
        
        effectComponent.RegisterTemporaryEffect(this, action);
    }
}