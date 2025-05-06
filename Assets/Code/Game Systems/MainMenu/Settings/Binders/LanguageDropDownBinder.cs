using TMPro;
using UnityEngine;

public class LanguageDropDownBinder : Binder
{
    [SerializeField] private TMP_Dropdown languageDropdown;
    
    protected override void LoadSetting()
    {
        languageDropdown.value = (int)Settings.Instance.CommonSetting.SelectedLanguage;
    }

    protected override void Setup()
    {
        languageDropdown.ClearOptions();
        languageDropdown.AddOptions(LanguageConfig.DisplayNames);
        languageDropdown.onValueChanged.AddListener(OnDropDownChanged);
    }

    private void OnDropDownChanged(int index)
    {
        Settings.Instance.CommonSetting.SelectedLanguage = LanguageConfig.OrderedLanguages[index];
    }
}