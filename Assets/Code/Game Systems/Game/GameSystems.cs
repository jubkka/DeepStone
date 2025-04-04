using UnityEngine;

public class GameSystems : MonoBehaviour
{
    [SerializeField] private GameObject components;
    
    public static GameSystems Instance;
    
    private InventoryComponent inventory;
    private EquipmentComponent equipment;
    private HotbarComponent hotbar;
    private EffectComponent effect;
    private HandComponent hand;
    private ChestComponent chest;
    private AttackComponent attack;
    
    private ItemUsageSystem itemUsageSystem;
    public ItemUsageSystem GetItemUsageSystem => itemUsageSystem;
    public InventoryComponent GetInventoryComponent => inventory;
    public EquipmentComponent GetEquipmentComponent => equipment;
    public HotbarComponent GetHotbarComponent => hotbar;
    public HandComponent GetHandComponent => hand;
    public ChestComponent GetChestComponent => chest;
    public AttackComponent GetAttackComponent => attack;

    private void Awake()
    {
        Instance = this;

        GetComponents();
        
        itemUsageSystem = new ItemUsageSystem(equipment, effect, hand, attack);
    }

    private void GetComponents()
    {
        inventory = components.GetComponentInChildren<InventoryComponent>();
        equipment = components.GetComponentInChildren<EquipmentComponent>();
        hotbar = components.GetComponentInChildren<HotbarComponent>();
        chest = components.GetComponentInChildren<ChestComponent>();
        effect = components.GetComponentInChildren<EffectComponent>();
        hand = components.GetComponentInChildren<HandComponent>();
        attack = components.GetComponentInChildren<AttackComponent>();
    }
}