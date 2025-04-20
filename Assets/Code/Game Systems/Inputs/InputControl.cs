using UnityEngine;

public abstract class InputControl : MonoBehaviour
{
    protected InputManager inputManager;
    protected PlayerControls controls;

    protected virtual void Start()
    {
        inputManager = InputManager.instance;
        controls = inputManager.controls;
        
        SubscribeToControls();
    }

    protected void OnEnable()
    {
        if (inputManager != null && controls != null)
            SubscribeToControls();
    }

    protected void OnDisable()
    {
        if (controls != null)
            UnsubscribeFromControls();
    }

    protected void OnDestroy()
    {
        UnsubscribeFromControls();
    }
    
    protected abstract void SubscribeToControls();
    protected abstract void UnsubscribeFromControls();
}