using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    [HideInInspector] public PlayerControls controls;

    private void Awake()
    {
        instance = this;
        controls = new PlayerControls();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    public void SwitchToInventory()
    {
        controls.Disable();
        controls.Inventory.Enable();
        
        CursorManager.ChangeState(true);
    }

    public void SwitchToPlayer()
    {
        controls.Enable();
        controls.Inventory.Close.Disable();
        
        CursorManager.ChangeState(false);
    }

    public void SwitchToPause()
    {
        controls.Disable();
        controls.PauseGame.Enable();
        
        CursorManager.ChangeState(true);
    }

    public void SwitchToChest()
    {
        controls.Disable();
        controls.Chest.Enable();
        
        CursorManager.ChangeState(true);
    }
}