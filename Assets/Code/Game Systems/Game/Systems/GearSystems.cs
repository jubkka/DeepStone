using System.Collections.Generic;

public class GearSystems : Systems
{
    public static GearSystems Instance;
    
    //gear
    private InventoryComponent inventory;
    private EquipmentComponent equipment;
    private SpellComponent spell;
    private HotbarComponent hotbar;
    private ChestComponent chest;
    
    //item
    private ItemUsageComponent itemUsageComponent;
    
    public InventoryComponent GetInventoryComponent => inventory;
    public EquipmentComponent GetEquipmentComponent => equipment;
    public SpellComponent GetSpellComponent => spell;
    public HotbarComponent GetHotbarComponent => hotbar;
    public ChestComponent GetChestComponent => chest;
    public ItemUsageComponent GetItemUsageComponent => itemUsageComponent;

    private void Awake()
    {
        Instance = this;
        
        GetComponents();
        Initialization();
    }

    private void Start()
    {
        LoadFromOrigin();
    }

    protected override void GetComponents()
    {
        inventory = components.GetComponentInChildren<InventoryComponent>();
        equipment = components.GetComponentInChildren<EquipmentComponent>();
        spell = components.GetComponentInChildren<SpellComponent>();
        hotbar = components.GetComponentInChildren<HotbarComponent>();
        chest = components.GetComponentInChildren<ChestComponent>();

        itemUsageComponent = components.GetComponentInChildren<ItemUsageComponent>();
    }

    private void Initialization()
    {
        inventory.Initialize();
        equipment.Initialize();
        spell.Initialize();
        hotbar.Initialize();
        chest.Initialize();
    }

    private void LoadFromOrigin()
    {
        List<Item> items = CreateNewItems(PlayerSetup.Instance.SelectedOrigin);
        
        inventory.AddItems(items);
        equipment.TryEquipItems(items);
        hotbar.AddItems(items);
    }

    private List<Item> CreateNewItems(Origin origin)
    {
        List<Item> items = new();
        
        foreach (var item in origin.GetItems)
            items.Add(new Item(item.data, item.Amount));

        return items;
    }
}