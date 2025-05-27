public class AudioSystems : Systems
{
    public static AudioSystems Instance;
    
    private MusicManager music;
    private EffectsAudioManager effects;
    
    public MusicManager GetMusic => music;
    public EffectsAudioManager GetEffects => effects;
    protected override void Init()
    {
        Instance = this;
    }

    public override void LoadFromOrigin(Origin origin)
    {
        throw new System.NotImplementedException();
    }

    public override void LoadFromSave()
    {
        throw new System.NotImplementedException();
    }
}