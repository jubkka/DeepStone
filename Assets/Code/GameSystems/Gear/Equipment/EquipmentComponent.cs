public class EquipmentComponent : GearComponent
{
    public static EquipmentComponent Instance;
    protected void Awake() => Initialize();
    protected override void Singleton() 
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);  
    }
    protected override void Initialize()
    {
        Singleton();
        
        storage = new GearStorage(maxSize);
        manager = new EquipmentManager(storage);
        uiManager = GetComponent<GearUIComponent>();

        gearName = "Equipment";

        base.Initialize();
    }
    public override bool MoveItems(int fromIndex, int targetIndex)
    {
        return false;
    }
}