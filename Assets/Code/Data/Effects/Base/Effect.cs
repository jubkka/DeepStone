using UnityEngine;

public abstract class Effect : ScriptableObject, IItemEffect
{
    [SerializeField] protected string nameEffect;
    [SerializeField] protected EffectType effectType;
    public string Name => nameEffect;
    public EffectType EffectType => effectType;
    public abstract string GetDescription();
    public abstract void Apply(EffectComponent effectComponent);
}

public enum EffectType
{
    defensive,
    offensive,
    healing,
}