using System;
using UnityEngine;

public abstract class Indicator
{
    [SerializeField] private float current;
    [SerializeField] private float max;
    [SerializeField] private IndicatorView view;

    public float Current => current;
    public float Max => max;

    public Indicator(float current, float max, IndicatorView view)
    {
        this.current = current;
        this.max = max;
        this.view = view;

        view.Init(current, max);
    }

    public void Increase(float value) 
    {
        current = Math.Min(max, current + value);
        view.ChangeValue(current, max);
    }
    public void Decrease(float value) 
    {
        current = Math.Max(0, current - value);
        view.ChangeValue(current, max);
    } 
    public void ChangeMax(float value) 
    { 
        max = Math.Max(0, value);
        view.ChangeValue(current, max);
    }
}

[Serializable]
public class Health : Indicator
{
    public Health(float current, float max, IndicatorView view) : base(current, max, view) {}
}

[Serializable]
public class Mana : Indicator 
{
    public Mana(float current, float max, IndicatorView view) : base(current, max, view) {}
}

[Serializable]
public class Stamina : Indicator 
{
    public Stamina(float current, float max, IndicatorView view) : base(current, max, view) {}
}