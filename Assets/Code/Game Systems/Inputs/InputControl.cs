using UnityEngine;

public abstract class InputControl : MonoBehaviour
{
    protected InputManager inputManager;
    protected PlayerControls controls;

    protected virtual void Start()
    {
        SubscribeToControls();
    }

    private void Init()
    {
        if (inputManager == null)
        {
            inputManager = InputManager.Instance;
            controls = InputManager.Controls;
        }
        else
            controls = InputManager.Controls;
    }

    protected void OnEnable()
    {
        Init();
        SubscribeToControls();
    }

    protected void OnDisable()
    {
        Init();
        UnsubscribeFromControls();
    }

    protected void OnDestroy()
    {
        UnsubscribeFromControls();
    }
    
    protected abstract void SubscribeToControls();
    protected abstract void UnsubscribeFromControls();
}