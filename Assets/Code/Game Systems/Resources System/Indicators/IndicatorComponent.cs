using System;
using UnityEngine;

public class IndicatorComponent : MonoBehaviour
{
    [Header("Indicator Views")]
    [SerializeField] private IndicatorView healthView;
    [SerializeField] private IndicatorView manaView;
    [SerializeField] private IndicatorView staminaView;
    
    private Health health;
    private Mana mana;
    private Stamina stamina;
    public Health Health => health;
    public Mana Mana => mana;
    public Stamina Stamina => stamina;
    
    public event Action OnHealthZero;
    
    public void InitFromOrigin(Origin origin)
    {
        health = new Health(origin.GetHealth, origin.GetHealth, healthView);
        mana = new Mana(origin.GetMana, origin.GetMana, manaView);
        stamina = new Stamina(origin.GetStamina, origin.GetStamina, staminaView);
    }

    public void InitFromSave() //TODO
    {
        health = new Health(1, 1, healthView);
        mana = new Mana(1, 1, manaView);
        stamina = new Stamina(1, 1, staminaView);
    }

    public void Heal(int value) => health.Increase(value);

    public void Hit(int value)
    {
        health.Decrease(value);
        
        if (health.Current <= 0)
            OnHealthZero?.Invoke();
    }
    
    public void Cast(int value) => mana.Decrease(value);
    public void RestoreMana(int value) => mana.Decrease(value);
}