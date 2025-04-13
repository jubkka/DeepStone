using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PauseManager : MonoBehaviour
{
    [Header("UI Element")]
    [SerializeField] private CanvasGroup menu;
    
    public static bool isPaused;
    
    private List<IPausable> pausableScripts;
    private PostProcessLayer postProcessLayer;

    public event Action<bool> OnControlMenuChanged; 

    private void Start()
    {
        postProcessLayer = Camera.main.GetComponent<PostProcessLayer>();
        
        pausableScripts = FindObjectsOfType<MonoBehaviour>()
                            .OfType<IPausable>()
                            .ToList();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            CallMenu();
    }

    public void CallMenu()
    {
        ChangeMenuState();
        
        Time.timeScale = isPaused ? 0 : 1;

        foreach (var script in pausableScripts)
        {
            script.OnPause(isPaused);
        }
        
        PlayerMovementControl.CursorStateChange(isPaused);
    }

    private void ChangeMenuState()
    {
        isPaused = !isPaused;
        
        postProcessLayer.enabled = !postProcessLayer.enabled; // on/off vignette  
        menu.alpha = 1f - menu.alpha;  
        menu.blocksRaycasts = isPaused;
    }
}
