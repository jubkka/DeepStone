using UnityEngine;

public class DeathComponent : MonoBehaviour
{
    [SerializeField] private DeathScreen deathScreen;

    public void Init(IndicatorComponent indicator)
    {
        indicator.OnHealthZero += OnDeath;
    }

    private void OnDeath()
    {
        deathScreen.Show();
        InputManager.Instance.SwitchToDeathScreen();
        SFXAudioManager.Instance.PlaySound("Lose");
    }
}
