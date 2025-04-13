using System;
using UnityEngine;

public class GoldModel
{
    private int count;
    private int maxCount = 100000;
    public int GetCount => count;
    public int GetMaxCount => maxCount;
    public static event Action<int> OnGoldChanged;

    public GoldModel(int count)
    {
        this.count = count;
    }

    public void Increase(int amount) 
    {
        count = Mathf.Min(maxCount, count + amount);

        OnGoldChanged?.Invoke(count);
    }

    public void Decrease(int amount) 
    {
        count = Mathf.Max(0, count - amount);

        OnGoldChanged?.Invoke(count);
    }
}
