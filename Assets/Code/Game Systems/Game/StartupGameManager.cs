using UnityEngine;

public class StartupGameManager : MonoBehaviour
{
    private void Awake()
    {
        GameManager.CursorChangeState(false);
    }
}