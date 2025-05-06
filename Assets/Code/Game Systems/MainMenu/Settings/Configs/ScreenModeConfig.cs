using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ScreenModeConfig
{
    public static Dictionary<FullScreenMode, string> ScreenModes = new()
    {
        { FullScreenMode.FullScreenWindow, "FullScreen Window"},
        { FullScreenMode.Windowed, "Window"},
    };
    
    public static List<FullScreenMode> OrderedScreenMode => ScreenModes.Keys.ToList();
    public static List<string> DisplayNames => ScreenModes.Values.ToList();
}