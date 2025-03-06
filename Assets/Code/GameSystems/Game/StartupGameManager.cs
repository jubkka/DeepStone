using UnityEngine;

public class StartupGameManager : MonoBehaviour
{
    private void Awake()
    {
        HideCursor();
    }

    private void HideCursor() 
    {
        Cursor.visible = !Cursor.visible;
        Cursor.lockState = CursorLockMode.Locked;
    }
}