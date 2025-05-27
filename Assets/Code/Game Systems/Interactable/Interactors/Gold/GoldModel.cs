using UnityEngine;

public class GoldModel
{
    private readonly GoldView goldView;

    private int count;
    public int GetCount => count;
    
    public GoldModel(int count, GoldView goldView)
    {
        this.count = count;
        this.goldView = goldView;
    }

    public void Increase(int amount) 
    {
        count = Mathf.Min(100000, count + amount);

        goldView.ChangeText(count);
    }

    public void Decrease(int amount) 
    {
        count = Mathf.Max(0, count - amount);

        goldView.ChangeText(count);
    }
}
