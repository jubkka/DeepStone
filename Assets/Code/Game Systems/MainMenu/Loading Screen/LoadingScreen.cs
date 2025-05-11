using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private string sceneName;
    
    private void Start()
    {
        StartCoroutine(LoadSceneASync());
    }

    private IEnumerator LoadSceneASync()
    {
        yield return new WaitForSeconds(1f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            yield return null; 
        }
    }
}