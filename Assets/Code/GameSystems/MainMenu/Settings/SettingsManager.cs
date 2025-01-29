using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public void OnApply()
    {
        Screen.SetResolution(Settings.Resolution["width"], Settings.Resolution["height"], Settings.SelectedFullScreenMode);
        Application.targetFrameRate = Settings.FramerateLimit;
        QualitySettings.vSyncCount = Settings.IsSync;


        SaveSettings();
    }

    public void OnRevert() 
    {

    }

    private void UpdateUI() 
    {

    }
    private void SaveSettings() 
    {
        //Common
        PlayerPrefs.SetInt("Language", (int)Settings.SelectedLanguage);
        
        //Graphics
        PlayerPrefs.SetInt("Width", Settings.Resolution["width"]);
        PlayerPrefs.SetInt("Height", Settings.Resolution["height"]);
        PlayerPrefs.SetInt("FramerateLimit", Settings.FramerateLimit);
        PlayerPrefs.SetInt("GraphicsQuality", (int)Settings.SelectedGraphicsQuality);
        PlayerPrefs.SetInt("FramerateMode", (int)Settings.SelectedFramerateMode);
        
        //Volume
        PlayerPrefs.SetInt("Effects", Settings.Effects);
        PlayerPrefs.SetInt("Music", Settings.Music);

        //Controls
        PlayerPrefs.SetInt("MouseSensivity", Settings.MouseSensivity);

        PlayerPrefs.Save();
    }
}
