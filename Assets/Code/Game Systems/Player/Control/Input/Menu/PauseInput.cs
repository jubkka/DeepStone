using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.PostProcessing;

public class PauseInput : InputControl
{
    [Header("UI Element")]
    [SerializeField] private CanvasGroup menu;
    private PostProcessLayer postProcessLayer;
    
    private bool isPaused = false;

    protected override void Start()
    {
        postProcessLayer = Camera.main?.GetComponent<PostProcessLayer>();
        
        base.Start();
    }
    
    protected override void SubscribeToControls()
    {
        controls.PauseGame.Pause.performed += OnPause;
        controls.PauseGame.Enable();
    }

    protected override void UnsubscribeFromControls()
    {
        controls.PauseGame.Pause.performed -= OnPause;
        controls.PauseGame.Disable();
    }

    private void OnPause(InputAction.CallbackContext context)
    {
        CallMenu();
    }

    public void CallMenu()
    {
        isPaused = !isPaused;
        
        if (isPaused)
            inputManager.SwitchToPause();
        else
            inputManager.SwitchToPlayer();
        
        ChangeMenuState();
    }

    private void ChangeMenuState()
    {
        Time.timeScale = isPaused ? 0 : 1;
        postProcessLayer.enabled = isPaused; // on/off vignette  
        menu.alpha = isPaused ? 1 : 0;  
        menu.blocksRaycasts = isPaused;
        
        if (EnemiesPauser.Instance is not null)
            EnemiesPauser.Instance.ChangeStateEnemies(isPaused);
    }
}
