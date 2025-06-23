using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SFXSliderBinder : Binder
{
    [SerializeField] private Slider sfx;
    [SerializeField] private TextMeshProUGUI sfxTMP;

    protected override void LoadSetting()
    {
        float value = Settings.Instance.VolumeSetting.SFX;
        
        sfxTMP.text = value + "%";
        sfx.value = value;
    }

    protected override void Setup()
    {
        sfx.onValueChanged.AddListener(OnSFXSliderChanged);
    }

    private void OnSFXSliderChanged(float value)
    {
        sfxTMP.text = value + "%";
        Settings.Instance.VolumeSetting.SFX = (int)value;
    }
}