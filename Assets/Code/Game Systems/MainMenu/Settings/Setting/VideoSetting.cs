using System;
using UnityEngine;

[Serializable]
public class VideoSetting : Setting
{
    private Resolution resolution;
    
    [SerializeField] private FullScreenMode screenMode;
    [SerializeField] private bool vSync;

    public Resolution CurrentResolution
    {
        get => resolution;
        set => resolution = value;
    }

    public bool VSync
    {
        get => vSync;
        set => vSync = value;
    }

    public FullScreenMode ScreenMode
    {
        get => screenMode;
        set => screenMode = value;
    }
    
    public override void Save()
    {
        PlayerPrefs.SetInt("ResolutionWidth", resolution.width);
        PlayerPrefs.SetInt("ResolutionHeight", resolution.height);
        PlayerPrefs.SetInt("ScreenMode", (int)screenMode);
        PlayerPrefs.SetInt("VSync", vSync ? 1 : 0);
        
        PlayerPrefs.Save();
    }

    public override void Default()
    {
        resolution = Screen.resolutions[Screen.resolutions.Length - 1];
        screenMode = FullScreenMode.FullScreenWindow;
        vSync = true;
    }

    public override void Apply()
    {
        Screen.SetResolution(resolution.width, resolution.height, screenMode);
        QualitySettings.vSyncCount = vSync ? 1 : 0;
        
        Save();
    }

    public override void Load()
    {
        int width = PlayerPrefs.GetInt("ResolutionWidth", Screen.currentResolution.width);
        int height = PlayerPrefs.GetInt("ResolutionHeight", Screen.currentResolution.height);
        resolution = new Resolution {width = width, height = height};
        
        screenMode = (FullScreenMode)PlayerPrefs.GetInt("ScreenMode", (int)FullScreenMode.FullScreenWindow);
        vSync = PlayerPrefs.GetInt("VSync", 1) == 1;
    }
}