using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Debbuger : InputControl
{
    [Header("Debug Elements")]
    [SerializeField] private GameObject fpsCounter;
    [SerializeField] private GameObject itemSpawner;
    
    [SerializeField] private IndicatorComponent indicator;
    [SerializeField] private LevelComponent level;
    [SerializeField] private EffectComponent effect;
    
    [SerializeField] private TemporaryEffect temporaryEffect;
    
    protected override void SubscribeToControls()
    {
        controls.Debug.ItemSpawner.performed += OnToggleItemSpawner;
        controls.Debug.FPS.performed += OnToggleFPS;
        controls.Debug.RestartScene.performed += OnRestartedScene;
        controls.Debug.Enable();
    }

    protected override void UnsubscribeFromControls()
    {
        controls.Debug.ItemSpawner.performed -= OnToggleItemSpawner;
        controls.Debug.FPS.performed -= OnToggleFPS;
        controls.Debug.RestartScene.performed -= OnRestartedScene;
        controls.Debug.Disable();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            indicator.Heal(1);
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            indicator.Hit(1f);
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
            level.AddExp(10);
        
        if (Input.GetKeyDown(KeyCode.H))
            effect.Apply(temporaryEffect);
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
