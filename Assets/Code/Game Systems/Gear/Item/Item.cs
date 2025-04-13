using System;
using System.Windows.Input;
using UnityEngine;

[Serializable]
public class Item
{
    #region Varibales
    public ItemData data;
    [SerializeField] private int amount;
    [SerializeField] private string uniqueId;
    public string GetUniqueId => uniqueId;
    public bool IsEmpty => data == null;
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
    public Item(ItemData data, int amount) 
    {
        this.data = data;
        this.amount = amount;
        this.uniqueId = Guid.NewGuid().ToString();
    }

    public void Use(ItemSlotType type)
    {
        var command = GameSystems.Instance.GetItemUsageSystem.GetCommandByContext(type, data);
        command?.Execute(this);
    }
}