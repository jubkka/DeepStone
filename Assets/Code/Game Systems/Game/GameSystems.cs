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
    
    private ItemUsageSystem itemUsageSystem;
    public ItemUsageSystem GetItemUsageSystem => itemUsageSystem;
    public InventoryComponent GetInventoryComponent => inventory;
    public EquipmentComponent GetEquipmentComponent => equipment;
    public HotbarComponent GetHotbarComponent => hotbar;
    public HandComponent GetHandComponent => hand;
    public ChestComponent GetChestComponent => chest;

    private void Awake()
    {
        Instance = this;

        GetComponents();
        
        itemUsageSystem = new ItemUsageSystem(equipment, effect, hand);
    }

    private void GetComponents()
    {
        inventory = components.GetComponent<InventoryComponent>();
        equipment = components.GetComponent<EquipmentComponent>();
        hotbar = components.GetComponent<HotbarComponent>();
        effect = components.GetComponent<EffectComponent>();
        hand = components.GetComponent<HandComponent>();
        chest = components.GetComponent<ChestComponent>();
    }
}