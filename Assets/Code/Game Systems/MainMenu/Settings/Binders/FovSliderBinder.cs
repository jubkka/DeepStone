using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FovSliderBinder : Binder
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI textTMP;
    
    protected override void LoadSetting()
    {
        slider.value = Settings.Instance.ControlSetting.Fov;
        textTMP.text = Settings.Instance.ControlSetting.Fov.ToString();
    }

    protected override void Setup()
    {
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        Settings.Instance.ControlSetting.Fov = (int)value;
        textTMP.text = value.ToString();
    }
}