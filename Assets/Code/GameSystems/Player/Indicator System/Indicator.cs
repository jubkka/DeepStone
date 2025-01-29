using UnityEngine;

[System.Serializable]
public abstract class Indicator
{
    [SerializeField] private int current;
    [SerializeField] private int max;
    [SerializeField] private IndicatorView view;

    public int Current => current;
    public int Max => max;

    public Indicator(int max, IndicatorView view)
    {
        this.max = max;
        current = max;
        this.view = view; 
    }

    public void Increase(int value) 
    {
        current += value;
        view.ChangeCurrnet(current, max);
    }
    public void Decrease(int value) 
    {
        current -= value;
        view.ChangeCurrnet(current, max);
    } 
    public void ChangeMax(int value) 
    { 
        max = value;
        view.ChangeMax(max);
    }
}

[System.Serializable]
public class Health : Indicator
{
    public Health(int max, IndicatorView view) : base(max, view) {}
}

[System.Serializable]
public class Mana : Indicator 
{
    public Mana(int max, IndicatorView view) : base(max, view) {}
}

[System.Serializable]
public class Stamina : Indicator 
{
    public Stamina(int max, IndicatorView view) : base(max, view) {}
}