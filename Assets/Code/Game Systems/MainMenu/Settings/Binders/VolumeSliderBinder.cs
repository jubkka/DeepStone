using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderBinder : Binder
{
    [SerializeField] private Slider sound;
    [SerializeField] private TextMeshProUGUI soundTMP;
    
    [SerializeField] private Slider effects;
    [SerializeField] private TextMeshProUGUI effectsTMP;

    protected override void LoadSetting()
    {
        soundTMP.text = Settings.Instance.VolumeSetting.Music.ToString();
        effectsTMP.text = Settings.Instance.VolumeSetting.Effects.ToString();
        
        sound.value = Settings.Instance.VolumeSetting.Music;
        effects.value = Settings.Instance.VolumeSetting.Effects;
    }

    protected override void Setup()
    {
        sound.onValueChanged.AddListener(OnSoundSliderChanged);
        effects.onValueChanged.AddListener(OnEffectsSliderChanged);
    }
    
    //Events

    private void OnSoundSliderChanged(float value)
    {
        soundTMP.text = value.ToString();
        Settings.Instance.VolumeSetting.Music = (int)value;
    }

    private void OnEffectsSliderChanged(float value)
    {
        effectsTMP.text = value.ToString();
        Settings.Instance.VolumeSetting.Effects = (int)value;
    }
}