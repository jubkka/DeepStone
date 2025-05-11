using System;
using UnityEngine;

[Serializable]
public class Item : GenericElementData
{
    #region Varibales
    public ElementData data;
    [SerializeField] private int amount;
    [SerializeField] private string uniqueId;

    public string GetUniqueId => uniqueId;
    public bool IsEmpty => data == null;
    public int GetMaxStackSize 
    {
        get 
        {
            if (data is StackableElementData stackableItem) 
                return stackableItem.GetMaxStackSize;
            else 
                return 1; 
        }
    }
    public int Amount 
    {
        get => amount;
        set
        { 
            amount = value;

            if (amount > 0)
                OnItemChanged?.Invoke();
            else
                OnItemCountZero?.Invoke(this);
        }
    }

    public event Action OnItemChanged;
    public event Action<Item> OnItemCountZero;
    
    #endregion

    public Item() {}
    public Item(ElementData data, int amount) 
    {
        this.data = data;
        this.amount = amount;
        this.uniqueId = Guid.NewGuid().ToString();
    }

    public void Use(ItemSlotType type)
    {
        var command = GearSystems.Instance.GetItemUsageComponent.GetCommandByContext(type, data);
        command?.Execute(this);
    }
}