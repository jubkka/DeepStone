using System;
using UnityEngine;

public abstract class Indicator
{
    [SerializeField] private int current;
    [SerializeField] private int max;
    [SerializeField] private IndicatorView view;

    public int Current => current;
    public int Max => max;

    public Indicator(int current, int max, IndicatorView view)
    {
        this.current = current;
        this.max = max;
        this.view = view;

        view.Init(current, max);
    }

    public void Increase(int value) 
    {
        current = Math.Min(max, current + value);
        view.ChangeValue(current, max);
    }
    public void Decrease(int value) 
    {
        current = Math.Max(0, current - value);
        view.ChangeValue(current, max);
    } 
    public void ChangeMax(int value) 
    { 
        max = Math.Max(0, value);
        view.ChangeValue(current, max);
    }
}

[Serializable]
public class Health : Indicator
{
    public Health(int current, int max, IndicatorView view) : base(current, max, view) {}
}

[Serializable]
public class Mana : Indicator 
{
    public Mana(int current, int max, IndicatorView view) : base(current, max, view) {}
}

[Serializable]
public class Stamina : Indicator 
{
    public Stamina(int current, int max, IndicatorView view) : base(current, max, view) {}
}