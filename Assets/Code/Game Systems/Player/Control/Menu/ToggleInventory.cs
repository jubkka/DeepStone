using System;
using UnityEngine;

public class ToggleInventory : MonoBehaviour, IPausable
{
    [SerializeField] private CanvasGroup gear;
    public event Action<bool> OnToogleChanged;
    public event Action OnInventoryClosed;

    private void Start()
    {
        InputManager.Instance.OnInventoryPressed += Toggle; 
    }

    public void Toggle() 
    {
        bool isGearOpen = gear.alpha == 0;
        ChangeState(isGearOpen);

        OnToogleChanged?.Invoke(isGearOpen);
    }

    private void ChangeState(bool state)
    {
        if (state)
            Open();
        else
            Close();
    }

    private void Close()
    {
        gear.alpha = 0f;
        OnInventoryClosed?.Invoke();
    }

    private void Open()
    {
        gear.alpha = 1f;
    }

    public void OnPause(bool isPaused)
    {
        ChangeState(false);
    }
}