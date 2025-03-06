using UnityEngine;

public class InventoryInfo : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private InventoryComponent inventoryComponent;

    [Header("Inventory storage")]
    [SerializeField] private GearStorage storage;

    private void Awake()
    {
        inventoryComponent.OnItemChanged += UpdateStorageInfo;
    }
    private void UpdateStorageInfo(int index)
    {
        storage = inventoryComponent.GetStorage;
    }
}