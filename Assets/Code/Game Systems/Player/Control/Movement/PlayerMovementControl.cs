using UnityEngine;

public class PlayerMovementControl : MonoBehaviour
{
    private static PlayerRotate rotate;
    private static PlayerMovement movement;
    private static ToggleInventory toggleInventory;
    private static PauseManager pauseManager;

    private void Awake() 
    {
        GetComponents();
        Subscribe();
    }
    public void GetComponents() 
    {
        rotate = GetComponentInChildren<PlayerRotate>();
        movement = GetComponentInChildren<PlayerMovement>();
        toggleInventory = GetComponentInChildren<ToggleInventory>();
        pauseManager = GetComponentInChildren<PauseManager>();
    }
    
    public void Subscribe() 
    {
        toggleInventory.OnToogleChanged += CursorStateChange;
        toggleInventory.OnToogleChanged += ControlStateChange;
        
        pauseManager.OnControlMenuChanged += CursorStateChange;
    }
    
    public static void CursorStateChange(bool state) 
    {
        Cursor.visible = state;
        Cursor.lockState = state ? CursorLockMode.None : CursorLockMode.Locked;
    }    
    public static void ControlStateChange(bool state) 
    {
        rotate.enabled = !state;
        movement.enabled = !state;
    }
}