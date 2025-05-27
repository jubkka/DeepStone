using UnityEngine;

public class CharacterStatsSystems : Systems
{
    public static CharacterStatsSystems Instance;

    [SerializeField] private IndicatorComponent indicator;
    [SerializeField] private EffectComponent effect;
    [SerializeField] private AttributeComponent attribute;
    [SerializeField] private LevelComponent level;
    
    [SerializeField] private WeightComponent weight;
    
    public IndicatorComponent Indicator => indicator;
    public EffectComponent Effect => effect;
    public AttributeComponent Attribute => attribute;

    protected override void Init()
    {
        Instance = this;
    }

    public override void LoadFromOrigin(Origin origin)
    {
        Init();

        level.InitFromOrigin(origin, attribute);
        attribute.InitFromOrigin(origin, level);
        indicator.InitFromOrigin(origin);
        effect = new(origin, indicator);
        
        weight.InitFromOrigin(origin, attribute);
    }

    public override void LoadFromSave()
    {
        Init();
    }
}