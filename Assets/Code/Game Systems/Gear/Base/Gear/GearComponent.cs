using System;
using System.Linq;
using UnityEngine;

public abstract class GearComponent : MonoBehaviour 
{
    [SerializeField] protected string gearName;
    [SerializeField] protected GearUIComponent uiManager;
    public int maxSize = 1;
    
    protected GearStorage Storage;
    protected GearManager Manager;
    public GearStorage GetStorage => Storage;

    public event Action<int> OnItemChanged;
    protected void Awake() => Initialize();
    protected void Start() => PostInitialize();

    protected virtual void Initialize() 
    {
        for (int index = 0; index < Storage.Items.Length; index++) Storage.Items[index] = new Item(); 

        Manager.OnItemChanged += NotifyItemChanged;
        
        uiManager.Initialize(this);
    }
    
    protected virtual void PostInitialize() { }
    
    public virtual bool AddItem(Item item, int index) 
    {   
        if (Manager.AddItem(item, index)) 
        {
            Debug.Log($"Add item in {gearName}: + {item.data.GetName} In slot index: {index}");
            return true;
        }

        Debug.Log($"Fail add item in {gearName}: {item.data.GetName} in slot index: {index}");
        return false;
    }
    public virtual void RemoveItem(int index) 
    {
        if (Manager.RemoveItem(index)) 
            Debug.Log($"Item delete from {gearName}");
        else 
            Debug.Log($"Item not delete from {gearName}");
    }
    public virtual void DropItem(int index) {}
    public abstract bool MoveItems(int fromIndex, int targetIndex); 
    public void NotifyItemChanged(int index) => OnItemChanged?.Invoke(index);
    public bool IsFull() => Storage.Items.All(item => item.data != null);
    public Item GetItem(int index) => IsValidIndex(index) ? Storage.Items[index] : null;
    public bool IsValidIndex(int index) => index >= 0 && index < Storage.Items.Length;
    public virtual bool ContainsItem(Item item, out int existingIndex) { existingIndex = -1; return false; }
}