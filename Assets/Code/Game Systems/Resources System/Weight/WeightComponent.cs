using System;
using UnityEngine;

public class WeightComponent : MonoBehaviour
{
    [SerializeField] private WeightView weightCurrentView;
    [SerializeField] private WeightView weightMaxView;
    
    private WeightModel weightModel;
    private AttributeComponent attribute;
    
    public event Action<int> OnWeightCurrentChanged;
    public event Action<int> OnWeightMaxChanged;

    public void InitFromOrigin(Origin origin, AttributeComponent attributeComponent, InventoryComponent inventory, EquipmentComponent equipment)
    {
        attribute = attributeComponent;
        
        inventory.OnItemAdded += GiveWeight;
        inventory.OnItemRemoved += TakeWeight;
        
        //equipment.OnEquiped
        //equipment.OnUnequiped
        
        CalculateWeightInventory(inventory);
        CalculateMaxWeight();
    }

    private void CalculateWeightInventory(InventoryComponent inventory)
    {
        //
    }

    public void InitFromSave()
    {
        OnWeightCurrentChanged?.Invoke(0);
    }

    private void CalculateMaxWeight()
    {
        int strength = attribute.GetAttribute(AttributeType.Strength).Value;
        int weightMax = 20 * strength; 
        
        weightModel = new WeightModel(weightMax, weightCurrentView, weightMaxView);
        
        SetWeightMax(weightMax);
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

    public void SetWeightMax(int weightMax)
    {
        weightModel.Max = weightMax;
        OnWeightMaxChanged?.Invoke(weightModel.Max);
    }
}