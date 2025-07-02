using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootstrapTestScene : MonoBehaviour
{
    [SerializeField] private string sceneName = "PlayerScene";

    private void Awake()
    {
        StartCoroutine(StartGameSceneASync());
    }
    
    private IEnumerator StartGameSceneASync()
    {
        AsyncOperation player = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        yield return new WaitUntil(() => player.isDone);
    }
}
