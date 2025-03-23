using UnityEngine;

public class StartupGameManager : MonoBehaviour
{
    private void Awake()
    {
        PlayerControlManager.CursorStateChange(false);
    }
}