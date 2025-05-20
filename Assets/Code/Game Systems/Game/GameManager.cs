using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    public static void CursorChangeState(bool state) 
    {
        Cursor.visible = state;
        Cursor.lockState = state ? CursorLockMode.None : CursorLockMode.Locked;
    }    
    
    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
