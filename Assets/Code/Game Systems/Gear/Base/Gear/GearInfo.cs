using UnityEngine;

public abstract class GearInfo : MonoBehaviour
{
    [SerializeField] protected GearComponent component;
    
    [Header("Storage")]
    [SerializeField] protected GearStorage storage;

    protected abstract void Initialize();
    
    protected virtual void Start()
    {
        Initialize();

        component.OnItemChanged += UpdateStorageInfo;
    }
    
    protected virtual void UpdateStorageInfo(int index)
    {
        storage = component.GetStorage;
    }
}