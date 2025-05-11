using UnityEngine;

public abstract class AudioManager : MonoBehaviour
{
    [SerializeField] protected AudioSource audioSource;
    
    public void Play(AudioClip clip)
    {
        audioSource.clip = clip;
        
        audioSource.Play();
    }

    public void Stop()
    {
        audioSource.Stop();
    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}