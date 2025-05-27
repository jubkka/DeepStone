using UnityEngine;

public class DeathComponent : MonoBehaviour
{
    [SerializeField] private DeathScreen deathScreen;
    private IndicatorComponent indicator;
    private InputManager inputManager;

    private void Start()
    {
        indicator = CharacterStatsSystems.Instance.Indicator;
        indicator.OnHealthZero += OnDeath;
        
        inputManager = InputManager.instance;
    }

    private void OnDeath()
    {
        deathScreen.Show();

        inputManager.SwitchToDeathScreen();
    }
}
