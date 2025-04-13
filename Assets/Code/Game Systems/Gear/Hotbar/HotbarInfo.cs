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
        component = GameSystems.Instance.GetHotbarComponent;
    }

    protected override void Start()
    {
        Initialize();

        component.OnItemChanged += UpdateStorageInfo;
        //hotbarControl.OnActiveItemChanged += UpdateActiveSlotInfo;
    }
    protected override void UpdateStorageInfo(int index)
    {
        storage = component.GetStorage;
    }
    private void UpdateActiveSlotInfo() 
    {
        //activeItem = hotbarControl.ActiveItem;
        activeSlot = hotbarControl.ActiveSlotIndex;
    }
}