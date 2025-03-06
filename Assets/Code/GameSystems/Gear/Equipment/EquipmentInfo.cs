using UnityEngine;

public class EquipmentInfo : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private EquipmentComponent equipmentComponent;

    [Header("Equipment storage")]
    [SerializeField] private GearStorage storage;

    private void Awake()
    {
        equipmentComponent.OnItemChanged += UpdateStorageInfo;
    }
    private void UpdateStorageInfo(int index)
    {
        storage = equipmentComponent.GetStorage;
    }
}