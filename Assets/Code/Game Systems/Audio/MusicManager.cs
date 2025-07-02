using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    public static MusicManager Instance => instance;
    
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioMixer audioMixer;
    
    [Header("List Musics")]
    [SerializeField] private SoundData mainMenuMusic;
    [SerializeField] private AudioClip ambientMusic;

    private void Singleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        instance = this;
    }

    public void Init()
    {
        Singleton();

        audioSource.clip = mainMenuMusic.AudioClip;
        audioSource.volume = mainMenuMusic.Volume;
        audioSource.Play();
    }
    
    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
    
    public void PlayAmbientMusic()
    {
        audioSource.clip = ambientMusic;
        audioSource.Play();
    }
}
