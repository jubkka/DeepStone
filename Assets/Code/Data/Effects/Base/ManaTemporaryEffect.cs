using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ManaTemporaryEffectData", menuName = "EffectData/ManaEffectData")]
public class ManaTemporaryEffect : TemporaryEffect
{
    [SerializeField] private int manaRecover;
    [SerializeField] private string manaColor = "#FFF1FF";
    
    public int GetManaRecover => manaRecover;

    public override string GetDescription()
    {
        return $"Mana Recover: <color={manaColor}>{manaRecover}";
    }

    public override void Apply(EffectComponent effectComponent)
    {
        Action action = 
            () => effectComponent.Indicator.RestoreMana(manaRecover);
        
        effectComponent.RegisterTemporaryEffect(this, action);
    }
}