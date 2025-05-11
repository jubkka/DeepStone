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
        controls.Player.ToggleInventory.Enable();
        
        GameManager.CursorChangeState(true);
    }

    public void SwitchToPlayer()
    {
        controls.Enable();
        controls.Inventory.Close.Disable();
        
        GameManager.CursorChangeState(false);
    }

    public void SwitchToPause()
    {
        controls.Disable();
        controls.PauseGame.Enable();
        
        GameManager.CursorChangeState(true);
    }

    public void SwitchToChest()
    {
        controls.Disable();
        controls.Chest.Enable();
        
        GameManager.CursorChangeState(true);
    }

    public void SwitchToDeathScreen()
    {
        controls.Disable();
        
        GameManager.CursorChangeState(true);
    }
}