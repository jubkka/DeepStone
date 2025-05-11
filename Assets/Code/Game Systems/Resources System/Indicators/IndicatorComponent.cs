using System;
using UnityEngine;

public class IndicatorComponent : MonoBehaviour
{
    [Header("Indicators")]
    [SerializeField] private Health health;
    [SerializeField] private Mana mana;
    [SerializeField] private Stamina stamina;
    
    [Header("Indicator Views")]
    [SerializeField] private IndicatorView healthView;
    [SerializeField] private IndicatorView manaView;
    [SerializeField] private IndicatorView staminaView;
    
    public event Action OnHealthZero;
    
    public void Init(Origin origin)
    {
        health = new Health(origin.GetHealth, origin.GetHealth, healthView);
        mana = new Mana(origin.GetMana, origin.GetMana, manaView);
        stamina = new Stamina(origin.GetStamina, origin.GetStamina, staminaView);
    }

    public void Heal(int value) => health.Increase(value);

    public void Damage(int value)
    {
        health.Decrease(value);
        
        if (health.Current == 0)
            OnHealthZero?.Invoke();
    }

    public void Hit(int value) => health.Decrease(value);
    public void Cast(int value) => mana.Decrease(value);
    public void RestoreMana(int value) => mana.Decrease(value);
}