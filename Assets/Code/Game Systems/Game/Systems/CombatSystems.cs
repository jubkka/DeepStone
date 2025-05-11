using UnityEngine;

public class CombatSystems : Systems
{
    public static CombatSystems Instance;
    
    private HandComponent hand;
    private AttackComponent attack;
    
    public HandComponent GetHandComponent => hand;
    public AttackComponent GetAttackComponent => attack;

    private void Awake()
    {
        Instance = this;
        GetComponents();
    }

    protected override void GetComponents()
    {
        hand = components.GetComponentInChildren<HandComponent>();
        attack = components.GetComponentInChildren<AttackComponent>();
    }
}