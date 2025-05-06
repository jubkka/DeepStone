using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivitySliderBinder : Binder
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI textTMP;
    
    protected override void LoadSetting()
    {
        slider.value = Settings.Instance.ControlSetting.MouseSensitivity;
        textTMP.text = Settings.Instance.ControlSetting.MouseSensitivity + "%";
    }

    protected override void Setup()
    {
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        Settings.Instance.ControlSetting.MouseSensitivity = (int)value;
        textTMP.text = value + "%";
    }
}