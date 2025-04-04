using System;
using UnityEngine;

public class WeightController : MonoBehaviour
{
    private WeightView weightView;
    
    private WeightModel weightModel;

    private void Start()
    {
        weightView = GetComponent<WeightView>();
        weightModel = new WeightModel(weightView);
        
        InventoryComponent inventory = GameSystems.Instance.GetInventoryComponent;
        inventory.OnItemAdded += GiveWeight;
        inventory.OnItemRemoved += TakeWeight;
    }

    public void GiveWeight(Item item)
    {
        weightModel.Current += item.data.GetWeight;
    }
    
    public void TakeWeight(Item item)
    {
        weightModel.Current -= item.data.GetWeight;
    }

    public void SetWeightMax(int weightMax)
    {
        weightModel.Max = weightMax;
    }
}