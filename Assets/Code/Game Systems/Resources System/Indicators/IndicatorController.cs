using UnityEngine;

public class IndicatorController : MonoBehaviour
{
    [Header("Current Values")]
    [SerializeField] private int healthCurrentPoint;
    [SerializeField] private int manaCurrentPoint;
    [SerializeField] private int staminaCurrentPoint;

    [Header("Max Values")]
    
    [SerializeField] private int healtMaxPoint;
    [SerializeField] private int manaMaxPoint;
    [SerializeField] private int staminaMaxPoint;

    [Header("Indicator Views")]
    [SerializeField] private IndicatorView healthView;
    [SerializeField] private IndicatorView manaView;
    [SerializeField] private IndicatorView staminaView;
    
    private Health health;
    private Mana mana;
    private Stamina stamina;

    public static IndicatorController Instance;

    private void Awake() => Singleton();
    private void Start() => Constructor();

    private void Singleton() 
    {
        if (Instance == null) 
            Instance = this;
        else 
            Destroy(gameObject);
    }

    private void Constructor() 
    {
        health = new Health(healthCurrentPoint, healtMaxPoint, healthView);
        mana = new Mana(manaCurrentPoint, manaMaxPoint, manaView);
        stamina = new Stamina(staminaCurrentPoint, staminaMaxPoint, staminaView);
    }

    public void Heal(int value) => health.Increase(value);
    public void Damage(int value) => health.Decrease(value);
    public void Hit(int value) => health.Decrease(value);
    public void Cast(int value) => mana.Decrease(value);
    public void RestoreMana(int value) => mana.Decrease(value);
}