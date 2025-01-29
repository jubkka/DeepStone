using UnityEngine;

public class IndicatorController : MonoBehaviour
{
    [Header("Indicators")]
    [SerializeField] private Health health;
    [SerializeField] private Mana mana;
    [SerializeField] private Stamina stamina;

    [Header("Indicator Views")]
    [SerializeField] private IndicatorView healthView;
    [SerializeField] private IndicatorView manaView;
    [SerializeField] private IndicatorView staminaView;

    private void Awake() 
    {
        health = new Health(20, healthView);
        mana = new Mana(20, manaView);
        stamina = new Stamina(20, staminaView);

        health.ChangeMax(health.Max);
        mana.ChangeMax(mana.Max);
        stamina.ChangeMax(stamina.Max);
    }

    public void Heal(int value) => health.Increase(value);
    public void Hit(int value) => health.Decrease(value);
    public void Cast(int value) => mana.Decrease(value); 
    public void RestoreMana(int value) => mana.Decrease(value);
}