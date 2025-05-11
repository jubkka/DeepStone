public class AudioSystems : Systems
{
    public static AudioSystems Instance;
    
    private MusicManager music;
    private EffectsAudioManager effects;
    
    public MusicManager GetMusic => music;

    private void Awake()
    {
        Instance = this;
        
        GetComponents();
    }

    protected override void GetComponents()
    {
        music = components.GetComponentInChildren<MusicManager>();
        effects = components.GetComponentInChildren<EffectsAudioManager>();
    }
}