using UnityEngine;

public class HotbarInfo : GearInfo
{
    [Header("Components")]
    [SerializeField] private HotbarInput hotbar;
    
    [Header("Active Slot")]
    [SerializeField] private int activeSlot;
    [SerializeField] private Item activeItem;

    protected override void Initialize()
    {
        component = GearSystems.Instance.Hotbar;
    }

    protected override void Start()
    {
        Initialize();

        component.OnItemChanged += UpdateStorageInfo;
        //hotbarControl.OnActiveItemChanged += UpdateActiveSlotInfo;
    }
    protected override void UpdateStorageInfo(int index)
    {
        items = component.GetItems;
    }
    private void UpdateActiveSlotInfo() 
    {
        //activeItem = hotbarControl.ActiveItem;
        activeSlot = hotbar.ActiveSlotIndex;
    }
}