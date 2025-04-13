using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class StartupMainMenuManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    private void Awake() 
    {
        SetPrimaryResolution();
        ResolutionDropdownAddOptions();
    }

    private void ResolutionDropdownAddOptions() 
    {
        Resolution[] resolutions = Screen.resolutions;
        List<string> readyResolutions = new List<string>();

        int widthPrevivous = 0;
        int heightPrevivous = 0;

        for (int i = 0; i < resolutions.Length; i++) 
        {
            if (resolutions[i].width != widthPrevivous && resolutions[i].height != heightPrevivous) 
                readyResolutions.Add(resolutions[i].width + "x" + resolutions[i].height);

            widthPrevivous = resolutions[i].width;
            heightPrevivous = resolutions[i].height;
        }

        readyResolutions.Reverse();

        resolutionDropdown.AddOptions(readyResolutions);
    }
    private void SetPrimaryResolution() 
    {
        int index = Screen.resolutions.Length - 1;
        int width = Screen.resolutions[index].width;
        int height = Screen.resolutions[index].height;

        Settings.Resolution["width"] = width;
        Settings.Resolution["height"] = height;

        resolutionDropdown.value = index;

        Screen.SetResolution(width,height,true);
    }
}
