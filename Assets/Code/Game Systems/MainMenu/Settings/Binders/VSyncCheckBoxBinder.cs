using UnityEngine;
using UnityEngine.UI;

public class VSyncCheckBoxBinder : Binder
{
    [SerializeField] private Toggle toggle;

    protected override void LoadSetting()
    {
        toggle.isOn = Settings.Instance.VideoSetting.VSync;
    }

    protected override void Setup()
    {
        toggle.onValueChanged.AddListener(ToggleChanged);
    }

    private void ToggleChanged(bool value)
    {
        Settings.Instance.VideoSetting.VSync = value;
    }
}