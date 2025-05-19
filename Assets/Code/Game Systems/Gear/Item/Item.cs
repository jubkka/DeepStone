using System;
using UnityEngine;

[Serializable]
public class Item
{
    #region Varibales
    public GenericElementData data;
    [SerializeField] private int amount;
    [SerializeField] private string uniqueId;
    
    public bool IsEmpty => data == null;
    public string GetUniqueId => uniqueId;
    public int GetMaxStackSize 
    {
        get 
        {
            if (data is StackableItemData stackableItem) 
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

    public Item(GenericElementData data)
    {
        this.data = data;
        amount = 1;
        
        uniqueId = Guid.NewGuid().ToString();
    }

    public Item(GenericElementData data, int amount) 
    {
        this.data = data;
        this.amount = amount;
        
        uniqueId = Guid.NewGuid().ToString();
    }

    public void Use(ItemSlotType type)
    {
        var command = GearSystems.Instance.ItemsUsage.GetCommandByContext(type, data);
        command?.Execute(this);
    }
}