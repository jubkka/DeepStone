using UnityEngine;

public class CombatSystems : Systems
{
    public static CombatSystems Instance;
    
    [SerializeField] private LeftHandComponent leftHand;
    [SerializeField] private RightHandComponent rightHand;
    [SerializeField] private MagicHandComponent magicHand;

    [SerializeField] private AttackComponent attack;
    [SerializeField] private SpellCastingComponent spell;

    public LeftHandComponent GetLeftHand => leftHand;
    public RightHandComponent GetRightHand => rightHand;
    public MagicHandComponent GetMagicHand => magicHand;
    
    public AttackComponent GetAttackComponent => attack;
    public SpellCastingComponent GetSpell => spell;

    protected override void Init()
    {
        Instance = this;
    }

    public override void LoadFromOrigin(Origin origin)
    {
        Init();
    }

    public override void LoadFromSave()
    {
        Init();
        
        // TODO
    }
}