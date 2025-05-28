using UnityEngine;

public class CharacterStatsSystems : Systems
{
    public static CharacterStatsSystems Instance;

    [SerializeField] private IndicatorComponent indicator;
    [SerializeField] private EffectComponent effect;
    [SerializeField] private AttributeComponent attribute;
    [SerializeField] private LevelComponent level;
    [SerializeField] private DefenceComponent defence;
    [SerializeField] private DamageComponent damage;
    
    [SerializeField] private WeightComponent weight;
    
    public IndicatorComponent Indicator => indicator;
    public EffectComponent Effect => effect;
    public AttributeComponent Attribute => attribute;

    protected override void Init()
    {
        Instance = this;
    }

    public override void LoadFromOrigin(Origin origin) { }

    public void LoadFromOrigin(Origin origin, InventoryComponent inventory, EquipmentComponent equipment)
    {
        Init();

        level.InitFromOrigin(origin, attribute);
        attribute.InitFromOrigin(origin, level);
        indicator.InitFromOrigin(origin);
        effect = new(origin, indicator);
        
        defence.InitFromOrigin(origin, equipment, effect);
        damage.Init(defence, indicator);
        
        weight.InitFromOrigin(origin, attribute, inventory, equipment);
    }

    public override void LoadFromSave()
    {
        Init();
    }
}