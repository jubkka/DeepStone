using UnityEngine;

public class EffectComponent : MonoBehaviour
{
    public static EffectComponent instance;
    
    private IndicatorController controller;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        controller = GameSystems.Instance.GetIndicator;
    }

    public void Heal(int healAmount) 
    {
        controller.Heal(healAmount);
    }
}
