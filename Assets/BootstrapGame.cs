using UnityEngine;

public class BootstrapGame : MonoBehaviour
{
    [SerializeField] private Settings settings;
    [SerializeField] private MusicManager musicManager;
    [SerializeField] private SFXAudioManager sfxAudioManager;
    
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        musicManager.Init();
        sfxAudioManager.Init();
        settings.Init();
    }
}