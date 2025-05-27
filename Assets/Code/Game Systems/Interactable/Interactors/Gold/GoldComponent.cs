using System;
using UnityEngine;

public class GoldComponent : MonoBehaviour 
{
    [SerializeField] private GoldView goldView;
    
    private GoldModel gold;
    
    public event Action<int> OnGoldChanged;

    public void LoadFromOrigin(Origin origin)
    {
        //gold = new GoldModel(origin, goldView); //TODO
        
        OnGoldChanged?.Invoke(gold.GetCount);
    }

    public void LoadFromSave()
    {
        //gold = new GoldModel(origin, goldView); //TODO
        
        OnGoldChanged?.Invoke(gold.GetCount);
    }

    public void Give(int count) 
    {
        gold.Increase(count);

        OnGoldChanged?.Invoke(gold.GetCount);
        
        Debug.Log($"Gold count increase: {count}");
    } 
    public void Take(int count)
    {
        gold.Decrease(count);

        OnGoldChanged?.Invoke(gold.GetCount);
        
        Debug.Log($"Gold count decrease: {count}");
    } 
}