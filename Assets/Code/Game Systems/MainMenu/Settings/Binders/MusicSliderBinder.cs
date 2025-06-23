using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicSliderBinder : Binder
{
    [SerializeField] private Slider music;
    [SerializeField] private TextMeshProUGUI musicTMP;
    
    protected override void LoadSetting()
    {
        float value = Settings.Instance.VolumeSetting.Music;
        
        musicTMP.text = value + "%";
        music.value = value;
    }

    protected override void Setup()
    {
        music.onValueChanged.AddListener(OnMusicSliderChanged);
    }
    
    private void OnMusicSliderChanged(float value)
    {
        musicTMP.text = value + "%";
        Settings.Instance.VolumeSetting.Music = (int)value;
    }
}