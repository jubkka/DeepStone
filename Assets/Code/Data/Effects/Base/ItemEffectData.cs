using UnityEngine;

public abstract class ItemEffectData : ScriptableObject, IItemEffect
{
    public abstract void Apply(EffectComponent component);
}