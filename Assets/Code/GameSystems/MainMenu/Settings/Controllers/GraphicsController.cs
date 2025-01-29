using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsController : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private TMP_Dropdown screenModeDropdown;
    [SerializeField] private TMP_Dropdown qualityDropdown;
    [SerializeField] private Slider framerateLimitSlider;
    [SerializeField] private TextMeshProUGUI framerateLimitText;
    [SerializeField] private Toggle toggleVsync;
    public void ChangeResolution()
    {
        string[] resolution = resolutionDropdown.options[resolutionDropdown.value].text.Split("x"); //массив текущего выбранного разрешения 

        int width = int.Parse(resolution[0]);
        int height = int.Parse(resolution[1]);

        Settings.Resolution["width"] = width;
        Settings.Resolution["height"] = height;
    }
    public void ChangeScreenMode() 
    {
        int index = screenModeDropdown.value;

        Settings.SelectedFullScreenMode = (FullScreenMode)index+1;
    }
    public void ChangeQuality() 
    {
        int index = qualityDropdown.value;

        Settings.SelectedGraphicsQuality = (Settings.GraphicsQualities)index;
    }
    public void ChangeFramerateLimit() 
    { 
        if (framerateLimitSlider.value >= framerateLimitSlider.maxValue) 
        {
            framerateLimitText.text = "Without limits";
            
            Settings.FramerateLimit = 0;
            Settings.SelectedFramerateMode = Settings.FramerateMode.Unlimited;
        }
        else
        {
            framerateLimitText.text = framerateLimitSlider.value.ToString();

            Settings.FramerateLimit = (int)framerateLimitSlider.value;
            Settings.SelectedFramerateMode = Settings.FramerateMode.Limited;
        }
    }
    public void ChangeToogleVsync()
    {
        Settings.IsSync = toggleVsync.isOn ? 1 : 0;
    }
}
