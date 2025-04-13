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

        view.ChangeCurrent(this.current, this.max);
    }

    public void Increase(int value) 
    {
        current = Math.Min(max, current + value);
        view.ChangeCurrent(current, max);
    }
    public void Decrease(int value) 
    {
        current = Math.Max(0, current - value);
        view.ChangeCurrent(current, max);
    } 
    public void ChangeMax(int value) 
    { 
        max = Math.Max(0, value);
        view.ChangeCurrent(current, max);
    }
}

public class Health : Indicator
{
    public Health(int current, int max, IndicatorView view) : base(current, max, view) {}
}

public class Mana : Indicator 
{
    public Mana(int current, int max, IndicatorView view) : base(current, max, view) {}
}

public class Stamina : Indicator 
{
    public Stamina(int current, int max, IndicatorView view) : base(current, max, view) {}
}