using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenModeDropDownBinder : Binder
{
    [SerializeField] private TMP_Dropdown screenModeDropdown;

    protected override void LoadSetting()
    {
        FullScreenMode currentScreenMode = Settings.Instance.VideoSetting.ScreenMode;
        List<FullScreenMode> screenModes = ScreenModeConfig.OrderedScreenMode;

        screenModeDropdown.value = screenModes.IndexOf(currentScreenMode);
    }

    protected override void Setup()
    {
        screenModeDropdown.ClearOptions();
        screenModeDropdown.AddOptions(ScreenModeConfig.DisplayNames);
        
        screenModeDropdown.onValueChanged.AddListener(DropdownChanged);
    }

    private void DropdownChanged(int value)
    {
        var selectedMode = ScreenModeConfig.OrderedScreenMode[value];
        
        Settings.Instance.VideoSetting.ScreenMode = selectedMode;
    }
}