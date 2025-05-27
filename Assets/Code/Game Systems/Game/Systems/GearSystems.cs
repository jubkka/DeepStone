using System.Collections.Generic;
using UnityEngine;

public class GearSystems : Systems
{
    public static GearSystems Instance;

    [SerializeField] private InventoryComponent inventory;
    [SerializeField] private EquipmentComponent equipment;
    [SerializeField] private SpellComponent spell;
    [SerializeField] private HotbarComponent hotbar;
    [SerializeField] private ChestComponent chest;
    [SerializeField] private DropComponent drop;
    
    [Header("Resources")]
    [SerializeField] private WeightComponent weight;
    
    public InventoryComponent Inventory => inventory;
    public EquipmentComponent Equipment => equipment;
    public SpellComponent Spell => spell;
    public HotbarComponent Hotbar => hotbar;
    public ChestComponent Chest => chest;
    public DropComponent Drop => drop;

    protected override void Init()
    {
        Instance = this;
        
        inventory.Initialize();
        equipment.Initialize(inventory);
        hotbar.Initialize(inventory);
        drop.Initialize(inventory);
        spell.Initialize();
        chest.Initialize();
        
        weight.InitFromInventory(inventory);
    }
    
    public override void LoadFromSave()
    {
        Init();
        
        // List<Item> items = CreateNewItems(save.GetItems);
        // List<Item> equipments = CreateNewItems(save.GetItems);
        // List<Item> hotbars = CreateNewItems(save.GetItems); 
        // List<Item> spells =  CreateNewItems(save.GetSpells);

        //AddItems(items, equipments, hotbars, spells);
    }

    public override void LoadFromOrigin(Origin origin)
    {
        Init();
        
        List<Item> items = CreateNewItems(origin.GetItems);
        List<Item> equipments = CreateNewItems(origin.GetItems); //TODO
        List<Item> hotbars = CreateNewItems(origin.GetItems); //TODO
        List<Item> spells = CreateNewItems(origin.GetSpells);

        AddItemsToGears(items, equipments, spells, hotbars);
    }

    private void AddItemsToGears(List<Item> items, List<Item> equipments, List<Item> spells, List<Item> hotbars)
    {
        inventory.AddItems(items);
        equipment.AddItems(equipments);
        spell.AddItems(spells);
        hotbar.AddItems(hotbars);
    }

    private List<Item> CreateNewItems(List<Item> items)
    {
        List<Item> newItems = new();
        
        foreach (var item in items)
            newItems.Add(new Item(item.data, item.Amount));

        return newItems;
    }
}