using UnityEngine;

public class IndicatorInfo : MonoBehaviour
{
    [SerializeField] private IndicatorComponent indicatorComponent;
    
    [Header("Indicators")]
    [SerializeField] private Health health;
    [SerializeField] private Mana mana;
    [SerializeField] private Stamina stamina;

    private void Start()
    {
        health = indicatorComponent.Health;
        mana = indicatorComponent.Mana;
        stamina = indicatorComponent.Stamina;
    }
}