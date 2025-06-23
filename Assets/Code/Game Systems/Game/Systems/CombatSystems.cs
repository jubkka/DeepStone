using UnityEngine;

public class CombatSystems : Systems, ILoad
{
    public static CombatSystems Instance;
    
    [SerializeField] private LeftHandComponent leftHand;
    [SerializeField] private RightHandComponent rightHand;
    [SerializeField] private MagicHandComponent magicHand;

    [SerializeField] private IndicatorComponent indicator;
    [SerializeField] private EffectComponent effect;
    [SerializeField] private AttackComponent attack;
    [SerializeField] private DefenceComponent defence;
    [SerializeField] private DamageComponent damage;
    [SerializeField] private SpellCastingComponent spell;
    [SerializeField] private DeathComponent death;

    public LeftHandComponent LeftHand => leftHand;
    public RightHandComponent RightHand => rightHand;
    public MagicHandComponent MagicHand => magicHand;
    
    public IndicatorComponent Indicator => indicator;
    public EffectComponent Effect => effect;
    public AttackComponent Attack => attack;
    public DefenceComponent Defence => defence;
    public DamageComponent Damage => damage;
    public SpellCastingComponent Spell => spell;
    public DeathComponent Death => death;

    public override void Init(BootstrapCharacter character)
    {
        Instance = this;
        
        effect.Init(indicator, damage);
        attack.Init(rightHand, character.CharacterStatsSystems.Attribute, effect);
        defence.Init(character.GearSystems.Equipment, effect);
        damage.Init(defence, indicator);
        spell.Init(this, character.CharacterStatsSystems.Attribute);
        death.Init(indicator);
        
        rightHand.Init();
        leftHand.Init();
        magicHand.Init();
    }

    public void LoadFromOrigin(Origin origin)
    {
        indicator.LoadFromOrigin(origin);
        defence.LoadFromOrigin(origin);
    }

    public void LoadFromSave()
    {
        // TODO
    }
}