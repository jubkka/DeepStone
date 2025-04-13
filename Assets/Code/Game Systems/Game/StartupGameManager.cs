using UnityEngine;

public class StartupGameManager : MonoBehaviour
{
    private void Awake()
    {
        PlayerMovementControl.CursorStateChange(false);
    }
}