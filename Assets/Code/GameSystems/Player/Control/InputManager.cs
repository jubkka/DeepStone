using System;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    private Dictionary<KeyCode, Action> inputActions = new ();
    private Dictionary<Type, string> actionKeyBindings = new()
    {
        {typeof(PickUpAction), "PickUp"},
        {typeof(InteractAction), "Interact"},
    };


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    
    private void Start()
    {
        InputAction[] actions = FindObjectsOfType<InputAction>();

        foreach (InputAction action in actions)
        {
            Type actionType = action.GetType();

            if (actionKeyBindings.TryGetValue(actionType, out string keyName)) 
            {
                KeyCode key = KeysManager.GetKey(keyName);

                if (!inputActions.ContainsKey(key))
                    inputActions[key] = () => {};

                inputActions[key] += action.Execute; 
            }
        }
    }

    private void Update()
    {
        foreach (var key in inputActions.Keys)
        {
            if (Input.GetKeyDown(key))
            {
                inputActions[key]?.Invoke();
            }
        }
    }
}