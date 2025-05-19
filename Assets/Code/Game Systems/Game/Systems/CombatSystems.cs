public class CombatSystems : Systems
{
    public static CombatSystems Instance;
    
    private LeftHandComponent leftHand;
    private RightHandComponent rightHand;
    private MagicHandComponent magicHand;
    
    private AttackComponent attack;
    private SpellCastingComponent spell;

    public LeftHandComponent GetLeftHand => leftHand;
    public RightHandComponent GetRightHand => rightHand;
    public MagicHandComponent GetMagicHand => magicHand;
    
    public AttackComponent GetAttackComponent => attack;
    public SpellCastingComponent GetSpell => spell;

    private void Awake()
    {
        Instance = this;
        GetComponents();
    }

    protected override void GetComponents()
    {
        leftHand = components.GetComponentInChildren<LeftHandComponent>();
        rightHand = components.GetComponentInChildren<RightHandComponent>();
        magicHand = components.GetComponentInChildren<MagicHandComponent>();
        
        attack = components.GetComponentInChildren<AttackComponent>();
        spell = components.GetComponentInChildren<SpellCastingComponent>();
    }
}