using System;
using UnityEngine;

[Serializable]
public class CommonSetting : Setting
{
    [SerializeField] private Language selectedLanguage;
    public Language SelectedLanguage
    {
        get => selectedLanguage;
        set => selectedLanguage = value;
    }

    public override void Load()
    {
        selectedLanguage = (Language)PlayerPrefs.GetInt("SelectedLanguage", (int)Language.English);
    }

    public override void Save()
    {
        PlayerPrefs.SetInt("SelectedLanguage", (int)SelectedLanguage);
    }

    public override void Default()
    {
        selectedLanguage = Language.English;
    }

    public override void Apply()
    {
        
    }
}
