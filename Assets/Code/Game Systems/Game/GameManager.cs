using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Game States")] 
    [SerializeField] private Origin selectedOrigin;
    [SerializeField] private int currentLevel = 0;
    
    [Header("Scenes")]
    [SerializeField] private string mainMenuScene;
    [SerializeField] private string loadingScene;

    public int CurrentLevel
    {
        get => currentLevel;
        set => currentLevel = value;
    }

    public static GameManager Instance;
    
    private void Awake()
    {
        Instance = this;
        
        DontDestroyOnLoad(gameObject);
        CursorChangeState(true);
    }
    
    public void NewGame() => SceneManager.LoadScene(loadingScene);
    public void ReturnToMainMenu() => SceneManager.LoadScene(mainMenuScene);
    
    public static void CursorChangeState(bool state) 
    {
        Cursor.visible = state;
        Cursor.lockState = state ? CursorLockMode.None : CursorLockMode.Locked;
    }
    
    public void SelectOrigin(Origin origin) => selectedOrigin = origin;
}
