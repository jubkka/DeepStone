using UnityEngine;

public class StartupGameManager : MonoBehaviour
{
    private void Awake()
    {
        CursorManager.ChangeState(false);
    }
}