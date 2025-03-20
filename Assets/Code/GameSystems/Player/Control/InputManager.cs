using System;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    private Dictionary<KeyCode, Action> keyActions = new ();
    public event Action OnInteractPressed;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    
    private void Start()
    {
        AddKeyAction(KeysManager.GetKey("Interact"), () => OnInteractPressed?.Invoke());
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
            }
        }
    }
}