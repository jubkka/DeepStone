using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private string playerSceneName;
    [SerializeField] private string generationSceneName;
    
    private void Start()
    {
        StartCoroutine(LoadSceneASync());
    }

    private IEnumerator LoadSceneASync()
    {
        yield return new WaitForSeconds(1f);
        
        AsyncOperation player = SceneManager.LoadSceneAsync(playerSceneName);
        AsyncOperation generation = SceneManager.LoadSceneAsync(generationSceneName, LoadSceneMode.Additive);

        yield return new WaitUntil(() => player.isDone && generation.isDone);
    }
}