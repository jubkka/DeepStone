public interface IItemEffect
{
    public void Apply(EffectComponent effectComponent);
    public abstract string GetDescription();
}