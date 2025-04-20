using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Debbuger : MonoBehaviour
{
    [SerializeField] private GameObject fpsCounter;
    [SerializeField] private GameObject itemSpawner;

    private PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Debug.ItemSpawner.performed += OnToggleItemSpawner;
        playerControls.Debug.FPS.performed += OnToggleFPS;
        playerControls.Debug.RestartScene.performed += OnRestartedScene;
        playerControls.Debug.Enable();
    }

    private void OnDisable()
    {
        playerControls.Debug.ItemSpawner.performed -= OnToggleItemSpawner;
        playerControls.Debug.FPS.performed -= OnToggleFPS;
        playerControls.Debug.RestartScene.performed -= OnRestartedScene;
        playerControls.Debug.Disable();
    }

    private void Update()
    {
        DrawInteractRay();
    }

    private void DrawInteractRay()
    {
        //Raycaster.DrawRay(cam.position, cam.forward * distance, color);
    }

    private void OnToggleFPS(InputAction.CallbackContext context)
    {
        fpsCounter.SetActive(!fpsCounter.activeSelf);
    }
    
    private void OnToggleItemSpawner(InputAction.CallbackContext context)
    {
        itemSpawner.SetActive(!itemSpawner.activeSelf);
    }
    
    private void OnRestartedScene(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
