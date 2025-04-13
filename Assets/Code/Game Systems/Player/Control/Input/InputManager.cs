using System;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour, IPausable
{
    public static InputManager Instance;
    
    private Dictionary<KeyCode, Action> keyActions = new ();
    
    public event Action OnInteractPressed;
    public event Action OnInventoryPressed;
    public event Action OnUseItemPressed;
    public event Action<int> OnHotbarKeyPressed;
    public event Action OnHotbarSlotsScrolled;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        AddKeyAction(KeysManager.GetKey("Interact"), () => OnInteractPressed?.Invoke());
        AddKeyAction(KeysManager.GetKey("Inventory"), () => OnInventoryPressed?.Invoke());
        AddKeyAction(KeysManager.GetKey("UseItem"), () => OnUseItemPressed?.Invoke());
        
        //Hotbar
        AddKeyAction(KeysManager.GetKey("1"), () => OnHotbarKeyPressed?.Invoke(0));
        AddKeyAction(KeysManager.GetKey("2"), () => OnHotbarKeyPressed?.Invoke(1));
        AddKeyAction(KeysManager.GetKey("3"), () => OnHotbarKeyPressed?.Invoke(2));
        AddKeyAction(KeysManager.GetKey("4"), () => OnHotbarKeyPressed?.Invoke(3));
        AddKeyAction(KeysManager.GetKey("5"), () => OnHotbarKeyPressed?.Invoke(4));
        AddKeyAction(KeysManager.GetKey("6"), () => OnHotbarKeyPressed?.Invoke(5));
        AddKeyAction(KeysManager.GetKey("7"), () => OnHotbarKeyPressed?.Invoke(6));
        AddKeyAction(KeysManager.GetKey("8"), () => OnHotbarKeyPressed?.Invoke(7));
        AddKeyAction(KeysManager.GetKey("9"), () => OnHotbarKeyPressed?.Invoke(8));
    }

    private void AddKeyAction(KeyCode keyCode, Action action) 
    {
        if (!keyActions.ContainsKey(keyCode))
            keyActions[keyCode] = action;
        else
            keyActions[keyCode] += action;
    }

    private void Update()
    {
        foreach (var entry in keyActions)
        {
            if (Input.GetKeyDown(entry.Key))
            {
                entry.Value?.Invoke();
                return;
            }
        }
        
        OnHotbarSlotsScrolled?.Invoke();
    }

    public void OnPause(bool isPaused)
    {
        enabled = !isPaused;
    }
}