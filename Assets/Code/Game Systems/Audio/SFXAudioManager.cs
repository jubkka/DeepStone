using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SFXAudioManager : MonoBehaviour
{
    public static SFXAudioManager Instance { private set; get; }
    
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<SoundData> sounds;
    
    private Dictionary<string, SoundData> soundsDictionary;

    private void Singleton()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
    }

    public void Init()
    {
        Singleton();
        soundsDictionary = sounds.ToDictionary(s => s.SoundName);
    }

    public void PlaySound(string soundName)
    {
        if (soundsDictionary.TryGetValue(soundName, out SoundData soundData))
            audioSource.PlayOneShot(soundData.AudioClip, soundData.Volume);
        else
            Debug.Log($"{soundName} not found!");
    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}