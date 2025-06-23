using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    //Instance
    public static Settings Instance { get; private set; }
    
    //Common
    [SerializeField] private CommonSetting commonSetting = new();
    public CommonSetting CommonSetting => commonSetting;

    //Graphics
    [SerializeField] private VideoSetting videoSetting = new();
    public VideoSetting VideoSetting => videoSetting;
    
    //Volume
    [SerializeField] private VolumeSetting volumeSetting = new();
    public VolumeSetting VolumeSetting => volumeSetting;
    
    //Controls
    [SerializeField] private ControlSetting controlSetting = new();
    public ControlSetting ControlSetting => controlSetting;

    public event Action OnResetAction;

    private void Singleton()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
    }

    public void Init()
    {
        Singleton();
        LoadAllSettings();
        OnApply();
    }

    public void OnApply()
    {
        CommonSetting.Apply();
        VideoSetting.Apply();
        VolumeSetting.Apply();
        ControlSetting.Apply();
    }

    public void OnDefault()
    {
        CommonSetting.Default();
        VideoSetting.Default();
        VolumeSetting.Default();
        ControlSetting.Default();
        
        OnResetAction?.Invoke();
    }

    public void OnReturn()
    {
        LoadAllSettings();
        OnResetAction?.Invoke();
    }

    private void LoadAllSettings()
    {
        CommonSetting.Load();
        VideoSetting.Load();
        VolumeSetting.Load();
        ControlSetting.Load();
    }
}