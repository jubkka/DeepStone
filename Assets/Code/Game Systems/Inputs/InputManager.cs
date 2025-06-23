public class InputManager  //TODO Создавать при старте игры
{
    private static InputManager instance;
    private static PlayerControls controls;
    
    public static InputManager Instance => instance ??= new InputManager();
    public static PlayerControls Controls => controls ??= new PlayerControls();
    
    public void SwitchToInventory()
    {
        controls.Disable();
        
        controls.Inventory.Enable();
        controls.Spells.Enable();
        
        GameManager.CursorChangeState(true);
    }

    public void SwitchToPlayer()
    {
        controls.Enable();
        
        controls.Inventory.Disable();
        controls.Spells.Disable();
        controls.Chest.Disable();
        
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
        controls.Spells.Enable();
        
        GameManager.CursorChangeState(true);
    }

    public void SwitchToDeathScreen()
    {
        controls.Disable();
        
        GameManager.CursorChangeState(true);
    }
}