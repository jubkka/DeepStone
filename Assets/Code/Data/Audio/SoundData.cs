using UnityEngine;

[CreateAssetMenu(menuName = "Audio/Sound Data")]
public class SoundData : ScriptableObject
{
    [SerializeField] private string soundName;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] [Range(0f, 1f)] private float volume = 1f;
    
    public string SoundName => soundName;
    public AudioClip AudioClip => audioClip;
    public float Volume => volume;
}