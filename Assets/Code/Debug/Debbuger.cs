using UnityEngine;
using UnityEngine.SceneManagement;

public class Debbuger : MonoBehaviour
{
    [SerializeField] private GameObject fpsCounter;
    [SerializeField] private GameObject ItemSpawner;
    [SerializeField] private GameObject enemy;
    private KeyCode toggleFPSKey;
    private KeyCode toggleItemSpawnerKey;

    private void Awake()
    {
        toggleFPSKey = KeysManager.GetKey("FPS");   
        toggleItemSpawnerKey = KeysManager.GetKey("ItemSpawner");   
    }

    private void Update()
    {
        if (Input.GetKeyDown(toggleFPSKey)) ToggleGameObject(fpsCounter);
        if (Input.GetKeyDown(toggleItemSpawnerKey)) ToggleGameObject(ItemSpawner);
        if (Input.GetKeyDown(KeyCode.F11)) enemy.SetActive(!enemy.activeSelf);
        if (Input.GetKeyDown(KeyCode.F12)) SceneManager.LoadScene("TestScene");
    }

    private void ToggleGameObject(GameObject obj) => obj.SetActive(!obj.activeSelf); 
}
