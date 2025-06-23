using System;
using UnityEngine;

public class WeightComponent : MonoBehaviour, ILoad
{
    [SerializeField] private WeightView weightCurrentView;
    [SerializeField] private WeightView weightMaxView;
    
    [SerializeField] private int baseWeight;
    
    private WeightModel weightModel;

    public int GetCurrentWeight => weightModel.Current; 
    public int GetMaxWeight => weightModel.Max; 
    
    public event Action<int> OnWeightCurrentChanged;
    public event Action<int> OnWeightMaxChanged;

    public void Init(AttributeComponent attributeComponent, GearSystems gearSystems)
    {
        weightModel = new WeightModel(weightCurrentView, weightMaxView);
        Attribute attribute = attributeComponent.GetAttribute(AttributeType.Strength);
        
        Subscribe(attribute, gearSystems.Inventory, gearSystems.Equipment);
    }

    public void LoadFromOrigin(Origin origin)
    {
        
    }

    public void LoadFromSave()
    {
        throw new NotImplementedException();
    }

    private void Subscribe(Attribute attribute, InventoryComponent inventory, EquipmentComponent equipment)
    {
        attribute.OnAttributeChanged += CalculateMaxWeight;
        
        inventory.OnItemAdded += GiveWeight;
        inventory.OnItemCountZero += TakeWeight;
        inventory.OnItemRemoved += TakeWeight;
        
        equipment.OnItemRemoved += TakeWeight;
        equipment.OnItemAdded += GiveWeight;
    }

    private void CalculateMaxWeight(int strength)
    {
        int weightMax = baseWeight * strength; 
        
        weightModel.Max = weightMax;
        OnWeightMaxChanged?.Invoke(weightModel.Max);
    }

    public void GiveWeight(Item item)
    {
        if (item.data is ItemData data)
        {
            weightModel.Current += data.GetWeight;
            OnWeightCurrentChanged?.Invoke(weightModel.Current);
        }
    }
    
    public void TakeWeight(Item item)
    {
        if (item.data is ItemData data)
        {
            weightModel.Current -= data.GetWeight;
            OnWeightCurrentChanged?.Invoke(weightModel.Current);
        }
    }
}