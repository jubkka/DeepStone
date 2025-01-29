using System.Collections.Generic;
using UnityEngine;

public class Settings
{
    //Common
    public static Language SelectedLanguage {get; set;} = Language.Russian;
    public enum Language
    {
        Russian,
        English
    }

    //Graphics
    public static Dictionary<string, int> Resolution = new Dictionary<string, int>() 
    {
        {"width", 0},
        {"height", 0},
    };
    public static int FramerateLimit {get; set;} = 60;
    public static GraphicsQualities SelectedGraphicsQuality {get; set;} = GraphicsQualities.Medium;
    public static FullScreenMode SelectedFullScreenMode {get; set;} = FullScreenMode.MaximizedWindow;
    public static FramerateMode SelectedFramerateMode {get; set;} = FramerateMode.Limited;
    public static int IsSync;
    public enum FramerateMode 
    {
        Unlimited,
        Limited
    }
    public enum GraphicsQualities 
    {
        Low,
        Medium,
        High
    }
    
    //Volume
    public static int Effects {get; set;} = 50;
    public static int Music {get; set;} = 50;

    //Controls
    public static int MouseSensivity {get; set;} = 100;
}
