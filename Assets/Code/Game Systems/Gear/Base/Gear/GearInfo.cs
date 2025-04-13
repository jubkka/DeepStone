using UnityEngine;

abstract public class GearInfo : MonoBehaviour
{
    [Header("Storage")]
    [SerializeField] protected GearStorage storage;
    protected GearComponent component;

    abstract protected void Initialize();
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