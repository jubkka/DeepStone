using System.Collections.Generic;

public class GearSystems : Systems
{
    public static GearSystems Instance;
    
    public InventoryComponent Inventory { get; private set; }
    public EquipmentComponent Equipment { get; private set; }
    public SpellComponent Spell { get; private set; }
    public HotbarComponent Hotbar { get; private set; }
    public ChestComponent Chest { get; private set; }
    public ItemUsageSystem ItemsUsage { get; private set; }

    private void Awake()
    {
        Instance = this;
        
        GetComponents();
        Initialization();
    }

    private void Start()
    {
        LoadFromOrigin();
        
        ItemsUsage = new ItemUsageSystem();
    }

    protected override void GetComponents()
    {
        Inventory = components.GetComponentInChildren<InventoryComponent>();
        Equipment = components.GetComponentInChildren<EquipmentComponent>();
        Spell = components.GetComponentInChildren<SpellComponent>();
        Hotbar = components.GetComponentInChildren<HotbarComponent>();
        Chest = components.GetComponentInChildren<ChestComponent>();
    }

    private void Initialization()
    {
        Inventory.Initialize();
        Equipment.Initialize();
        Spell.Initialize();
        Hotbar.Initialize();
        Chest.Initialize();
    }

    private void LoadFromOrigin()
    {
        List<Item> items = CreateNewItems(PlayerSetup.Instance.SelectedOrigin.GetItems);
        List<Item> equipments; //TODO
        List<Item> spells =  CreateNewItems(PlayerSetup.Instance.SelectedOrigin.GetSpells);
        
        Inventory.AddItems(items);
        Equipment.AddItems(items);
        Hotbar.AddItems(items);
        Spell.AddItems(spells);
    }

    private List<Item> CreateNewItems(List<Item> items)
    {
        List<Item> newItems = new();
        
        foreach (var item in items)
            newItems.Add(new Item(item.data, item.Amount));

        return newItems;
    }
}