using UnityEngine;

public class WeightController : MonoBehaviour
{
    [SerializeField] private WeightView weightView;
    
    private WeightModel weightModel;

    private void Start()
    {
        weightModel = new WeightModel(weightView);
        
        InventoryComponent inventory = GearSystems.Instance.Inventory;
        
        inventory.OnItemAdded += GiveWeight;
        inventory.OnItemRemoved += TakeWeight;
    }

    private void GiveWeight(Item item)
    {
        if (item.data is ItemData data)
            weightModel.Current += data.GetWeight;
    }
    
    private void TakeWeight(Item item)
    {
        if (item.data is ItemData data)
            weightModel.Current -= data.GetWeight;
    }

    public void SetWeightMax(int weightMax)
    {
        weightModel.Max = weightMax;
    }
}