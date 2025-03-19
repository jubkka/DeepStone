using UnityEngine;

public class Debbuger : MonoBehaviour
{
    [SerializeField] private GameObject fpsCounter;
    [SerializeField] private GameObject ItemSpawner;

    private KeyCode toggleFPSKey;
    private KeyCode toggleItemSpawnerKey;

    private void Awake()
    {
         
        toggleFPSKey = KeysManager.GetKey("ToggleFPS");   
        toggleItemSpawnerKey = KeysManager.GetKey("ToggleItemSpawner");   
    }

    private void Update()
    {
        if (Input.GetKeyDown(toggleFPSKey)) ToggleGameObject(fpsCounter);
        if (Input.GetKeyDown(toggleItemSpawnerKey)) ToggleGameObject(ItemSpawner);
    }

    private void ToggleGameObject(GameObject obj) => obj.SetActive(!obj.activeSelf); 
}
