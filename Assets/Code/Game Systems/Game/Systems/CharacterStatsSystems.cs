using UnityEngine;

public class CharacterStatsSystems : Systems
{
    public static CharacterStatsSystems Instance;
    
    public IndicatorComponent Indicator { get; private set; }
    public EffectComponent Effect { get; private set; }
    public AttributeComponent Attribute { get; private set; }
    public LevelComponent Level { get; private set; }

    private void Awake()
    {
        Instance = this;
        
        GetComponents();
    }

    private void Start()
    {
        Initialization(PlayerSetup.Instance.SelectedOrigin);
    }

    protected override void GetComponents()
    {
        Indicator = components.GetComponentInChildren<IndicatorComponent>();
        Effect = components.GetComponentInChildren<EffectComponent>();
        Attribute = components.GetComponentInChildren<AttributeComponent>();
        Level = components.GetComponentInChildren<LevelComponent>();
    }

    private void Initialization(Origin origin)
    {
        Indicator.Init(origin);
        Attribute.Init(origin);
    }
}