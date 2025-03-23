using UnityEngine;

public class ChestComponent : GearComponent {
    [SerializeField] private InventoryComponent inventoryComponent;
    static public ChestComponent Instance;

    protected void Awake() => Initialize();
    protected override void Initialize() 
    {
        Singleton();

        storage = new GearStorage(maxSize);
        manager = new ChestManager(storage);
        uiManager = GetComponent<GearUIComponent>();

        gearName = "Chest";

        base.Initialize();
    }
    protected override void Singleton()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);   
    }
    public bool GiveItems(Item[] items)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if(!manager.AddItem(items[i], i)) 
                return false;
        }    
        return true;
    }
    public Item[] TakeItems() 
    {
        Item[] items = new Item[maxSize];

        for (int i = 0; i < storage.Items.Length; i++)
        {
            Item item = storage.Items[i];
            items[i] = new Item(item.data, item.Amount);
            RemoveItem(i);
        }   

        return items;
    }
    public override bool MoveItems(int fromIndex, int targetIndex)
    {
        if (manager.MoveItems(fromIndex, targetIndex)) 
            return true;

        return false;
    }
}