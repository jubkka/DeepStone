using UnityEngine;

public class EffectComponent : MonoBehaviour
{
    public static EffectComponent instance;
    
    private IndicatorComponent component;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        component = CharacterStatsSystems.Instance.GetIndicator;
    }

    public void Heal(int healAmount) 
    {
        component.Heal(healAmount);
    }
}
