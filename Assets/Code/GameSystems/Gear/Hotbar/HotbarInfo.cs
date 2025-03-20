using UnityEngine;

public class HotbarInfo : GearInfo
{

    [Header("Components")]
    [SerializeField] private HotbarInputControl hotbarControl;
    
    [Header("Active Slot")]
    [SerializeField] private int activeSlot;
    [SerializeField] private Item activeItem;

    protected override void Initialize()
    {
        component = HotbarComponent.Instance;
    }

    protected override void Start()
    {
        Initialize();

        component.OnItemChanged += UpdateStorageInfo;
        hotbarControl.OnItemChanged += UpdateActiveSlotInfo;
    }
    protected override void UpdateStorageInfo(int index)
    {
        storage = component.GetStorage;
    }
    private void UpdateActiveSlotInfo() 
    {
        activeItem = hotbarControl.GetActiveItem;
        activeSlot = hotbarControl.GetActiveSlot;
    }
}