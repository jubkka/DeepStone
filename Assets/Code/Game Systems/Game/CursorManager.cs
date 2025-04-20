using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static void ChangeState(bool state) 
    {
        Cursor.visible = state;
        Cursor.lockState = state ? CursorLockMode.None : CursorLockMode.Locked;
    }    
}