using System;
using UnityEngine;

public class IndicatorController : MonoBehaviour
{
    [Header("Current Values")]
    [SerializeField] private int healthCurrentPoint;
    [SerializeField] private int manaCurrentPoint;
    [SerializeField] private int staminaCurrentPoint;

    [Header("Max Values")]
    
    [SerializeField] private int healthMaxPoint;
    [SerializeField] private int manaMaxPoint;
    [SerializeField] private int staminaMaxPoint;

    [Header("Indicator Views")]
    [SerializeField] private IndicatorView healthView;
    [SerializeField] private IndicatorView manaView;
    [SerializeField] private IndicatorView staminaView;
    
    private Health health;
    private Mana mana;
    private Stamina stamina;
    
    public event Action OnHealthZero;
    
    private void Start() => Constructor();

    private void Constructor() 
    {
        health = new Health(healthCurrentPoint, healthMaxPoint, healthView);
        mana = new Mana(manaCurrentPoint, manaMaxPoint, manaView);
        stamina = new Stamina(staminaCurrentPoint, staminaMaxPoint, staminaView);
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