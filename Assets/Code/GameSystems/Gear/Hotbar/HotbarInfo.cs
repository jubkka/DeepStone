using UnityEngine;

public class HotbarInfo : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private HotbarInputControl hotbarControl;
    [SerializeField] private HotbarComponent hotbarComponent;

    [Header("Hotbar storage")]

    [SerializeField] private GearStorage storage;

    [Header("Active Slot")]
    [SerializeField] private int activeSlot;
    [SerializeField] private Item activeItem;

    private void Awake()
    {
        hotbarControl.OnItemChanged += UpdateActiveSlotInfo;
        hotbarComponent.OnItemChanged += UpdateStorageInfo;
    }
    private void UpdateStorageInfo(int index)
    {
        storage = hotbarComponent.GetStorage;
    }
    private void UpdateActiveSlotInfo() 
    {
        activeItem = hotbarControl.GetActiveItem;
        activeSlot = hotbarControl.GetActiveSlot;

    }
}