using System;
using System.Linq;
using TMPro;
using UnityEngine;

public class ResolutionDropdownBinder : Binder
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    
    private Resolution[] resolutions;
    
    protected override void Setup()
    {
        resolutions = Screen.resolutions
            .GroupBy(r => (r.width, r.height))
            .Select(g => g.First())
            .Reverse()
            .ToArray();
        
        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(resolutions.Select(
            r => $"{r.width}x{r.height}").ToList());
        
        resolutionDropdown.onValueChanged.AddListener(OnDropDownChanged);
    }

    protected override void LoadSetting()
    {
        var current = Settings.Instance.VideoSetting.CurrentResolution;
        
        int currentIndex = Array.FindIndex(resolutions, r => 
            r.width == current.width && 
            r.height == current.height);

        if (currentIndex >= 0)
            resolutionDropdown.value = currentIndex;
    }

    private void OnDropDownChanged(int index)
    {
        Settings.Instance.VideoSetting.CurrentResolution = resolutions[index];
    }
}