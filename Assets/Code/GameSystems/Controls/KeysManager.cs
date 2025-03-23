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
        {"Forward", KeyCode.W},
        {"Back", KeyCode.S},
        {"Left", KeyCode.D},
        {"Right", KeyCode.A},
        {"Inventory", KeyCode.Tab},
        {"PickUp", KeyCode.E},
        {"Interact", KeyCode.E},
        {"Attack", KeyCode.Mouse0},
        {"Spell", KeyCode.F},
        {"Menu", KeyCode.Escape},

        //Debug
        {"FPS", KeyCode.F10},
        {"ItemSpawner", KeyCode.F9},
    };
    private static readonly Dictionary<int, KeyCode> keyCodesHotbar = new Dictionary<int, KeyCode>() 
    {
        {0, KeyCode.Alpha1},
        {1, KeyCode.Alpha2},
        {2, KeyCode.Alpha3},
        {3, KeyCode.Alpha4},
        {4, KeyCode.Alpha5},
        {5, KeyCode.Alpha6},
        {6, KeyCode.Alpha7},
        {7, KeyCode.Alpha8},
        {8, KeyCode.Alpha9},
    };
    public static Dictionary<int, KeyCode> GetKeyCodesHotbar => keyCodesHotbar;
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