using UnityEngine;

public class DeathComponent : MonoBehaviour
{
    [SerializeField] private DeathScreen deathScreen;
    [SerializeField] private PauseInput pauseInput;

    public void Init(IndicatorComponent indicator)
    {
        indicator.OnHealthZero += OnDeath;
    }

    private void OnDeath()
    {
        deathScreen.Show();
        InputManager.Instance.SwitchToDeathScreen();
        SFXAudioManager.Instance.PlaySound("Lose");
        
        Time.timeScale = 0;
    }
}
