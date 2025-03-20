using UnityEngine;

public static class ControlCursor 
{
    public static void ChangeStateCursor(bool isVisible) 
    {
        Cursor.visible = isVisible;
        Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
    }
}