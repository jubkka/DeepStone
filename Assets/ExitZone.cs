using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitZone : Interactable
{
    [SerializeField] private string LoaderSceneName = "LoadingScene";
    
    public override void Interact()
    {
        GameManager.Instance.CurrentLevel += 1;
        
        SceneManager.LoadScene(LoaderSceneName);
    }
}
