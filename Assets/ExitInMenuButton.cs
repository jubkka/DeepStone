using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitInMenuButton : MonoBehaviour
{
    [SerializeField] private List<GameObject> destroyObjects;
    
    public void Exit()
    {
        Debug.Log("Exit");
        
        Destroy(GameObject.FindGameObjectWithTag("GameController"));

        foreach (var objects in destroyObjects)
        {
            Destroy(objects);
        }
        
        Time.timeScale = 1;
        
        SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
    }
}
