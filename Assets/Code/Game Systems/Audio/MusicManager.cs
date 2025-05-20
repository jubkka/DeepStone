using UnityEngine;

public class MusicManager : AudioManager
{
    [SerializeField] private AudioClip mainMenuMusic;

    private void Awake()
    {
        audioSource.clip = mainMenuMusic;
    }
}
