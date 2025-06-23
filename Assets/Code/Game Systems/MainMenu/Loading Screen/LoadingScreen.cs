using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private string playerSceneName;
    [SerializeField] private string generationSceneName;
    
    private void Start()
    {
        if (GameManager.Instance?.CurrentLevel == 0)
            StartCoroutine(LoadNewGameSceneASync());
        else
            StartCoroutine(LoadNextLevelSceneASync());
    }

    private IEnumerator LoadNewGameSceneASync()
    {
        AsyncOperation generation = SceneManager.LoadSceneAsync(generationSceneName, LoadSceneMode.Single);
        AsyncOperation player = SceneManager.LoadSceneAsync(playerSceneName, LoadSceneMode.Additive);

        yield return new WaitUntil(() => player.isDone && generation.isDone);
    }
    
    private IEnumerator LoadNextLevelSceneASync()
    {
        AsyncOperation generation = SceneManager.LoadSceneAsync(generationSceneName, LoadSceneMode.Single);

        yield return new WaitUntil(() => generation.isDone);
    }
}