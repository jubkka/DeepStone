using System;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class ControlSetting : Setting
{
    [Header("Values")]
    [SerializeField] private int mouseSensitivity;
    [SerializeField] private int fov;
    
    [Header("Default Values")]
    [SerializeField] private int defaultMouseSensitivity;
    [SerializeField] private int defaultFov;
    
    public int MouseSensitivity
    {
        get => mouseSensitivity;
        set => mouseSensitivity = value;
    }

    public int Fov
    {
        get => fov;
        set => fov = value;
    }
    
    public override void Load()
    {
        LoadKeys();
        LoadSliders();
    }

    public override void Save()
    {
        SaveBindingOverrides();
        SaveSliders();
    }
    
    public override void Default()
    {
        mouseSensitivity = defaultMouseSensitivity;
        fov = defaultFov;
    }

    public override void Apply()
    {
        Save();
    }

    private void LoadSliders()
    {
        mouseSensitivity = PlayerPrefs.GetInt("MouseSensitivity", defaultMouseSensitivity);
        fov = PlayerPrefs.GetInt("Fov", defaultFov);
    }

    private void SaveSliders()
    {
        PlayerPrefs.SetInt("MouseSensitivity", MouseSensitivity);
        PlayerPrefs.SetInt("Fov", Fov);
        
        PlayerPrefs.Save();
    }

    private void LoadKeys()
    {
        string path = Path.Combine(Application.persistentDataPath, "bindings.json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            InputManager.instance.controls.LoadBindingOverridesFromJson(json);
        }
    }

    private void SaveBindingOverrides()
    {
        string json = GetBindingOverrides();
        File.WriteAllText(Path.Combine(Application.persistentDataPath, "bindings.json"), json);
    }

    private string GetBindingOverrides()
    {
        var overrides = InputManager.instance.controls.SaveBindingOverridesAsJson();
        return overrides;
    }
}