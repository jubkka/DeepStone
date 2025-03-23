using UnityEngine;

public  class PlayerControlManager : MonoBehaviour
{
    private static PlayerRotate rotate;
    private static PlayerMovement movement;
    private static ToggleInventory toggleInventory;
    private static ControlMenu controlMenu;

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
        controlMenu = GetComponentInChildren<ControlMenu>();
    }
    public void Subscribe() 
    {
        toggleInventory.OnToogleChanged += CursorStateChange;
        toggleInventory.OnToogleChanged += ControlStateChange;
        
        controlMenu.OnControlMenuChanged += CursorStateChange;
        controlMenu.OnControlMenuChanged += ControlStateChange;
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