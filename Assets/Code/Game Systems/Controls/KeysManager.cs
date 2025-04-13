using System;
using System.Collections.Generic;
using UnityEngine;

public static class KeysManager 
{
    public static event Action<string, KeyCode> OnKeyChanged;
    private static Dictionary<string, KeyCode> keyBindings = new Dictionary<string, KeyCode>();
    private static readonly Dictionary<string, KeyCode> defaultKeyBindings = new Dictionary<string, KeyCode>() 
    {
        //Main
        // {"Forward", KeyCode.W},
        // {"Back", KeyCode.S},
        // {"Left", KeyCode.D},
        // {"Right", KeyCode.A},
        {"Inventory", KeyCode.Tab},
        {"PickUp", KeyCode.E},
        {"Interact", KeyCode.E},
        {"UseItem", KeyCode.Mouse0},
        {"Spell", KeyCode.F},
        {"Close", KeyCode.Escape},
        
        //Hotbar
        {"1", KeyCode.Alpha1},
        {"2", KeyCode.Alpha2},
        {"3", KeyCode.Alpha3},
        {"4", KeyCode.Alpha4},
        {"5", KeyCode.Alpha5},
        {"6", KeyCode.Alpha6},
        {"7", KeyCode.Alpha7},
        {"8", KeyCode.Alpha8},
        {"9", KeyCode.Alpha9},

        //Debug
        {"FPS", KeyCode.F10},
        {"ItemSpawner", KeyCode.F9},
    };
    
    static KeysManager()
    {
        LoadKeys();
    }
    public static void LoadKeys() 
    {
        foreach (var key in defaultKeyBindings.Keys)
        {
            keyBindings[key] = (KeyCode)PlayerPrefs.GetInt(key, (int)defaultKeyBindings[key]);
        }
    } 
    public static void SetKey(string action, KeyCode newKey) 
    {
        if (!keyBindings.ContainsKey(action)) return;

        keyBindings[action] = newKey;
        PlayerPrefs.SetInt(action, (int)newKey);
        PlayerPrefs.Save();

        OnKeyChanged?.Invoke(action, newKey);
    } 
    public static KeyCode GetKey(string action) 
    {
        if (keyBindings.TryGetValue(action, out KeyCode key)) 
        {
            return key;
        }

        return KeyCode.None;
    }
}