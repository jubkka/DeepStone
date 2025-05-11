public class CharacterStatsSystems : Systems
{
    public static CharacterStatsSystems Instance;
    
    private IndicatorComponent indicator;
    private EffectComponent effect;
    
    private AttributeComponent attribute;
    private LevelComponent levelComponent;
    
    public IndicatorComponent GetIndicator => indicator;
    public EffectComponent GetEffectComponent => effect;
    public AttributeComponent GetAttribute => attribute;

    public LevelComponent LevelComponent => levelComponent;

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
        indicator = components.GetComponentInChildren<IndicatorComponent>();
        effect = components.GetComponentInChildren<EffectComponent>();
        attribute = components.GetComponentInChildren<AttributeComponent>();
        levelComponent = components.GetComponentInChildren<LevelComponent>();
    }

    private void Initialization(Origin origin)
    {
        indicator.Init(origin);
        attribute.Init(origin);
    }
}