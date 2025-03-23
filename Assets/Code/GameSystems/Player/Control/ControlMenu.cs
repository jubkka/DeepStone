using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ControlMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup menu;
    private PostProcessLayer postProcessLayer;
    private bool isMenuOpen = false;
    public event Action<bool> OnControlMenuChanged;

    private void Start()
    {
        InputManager.Instance.OnMenuPressed += CallMenu;
        postProcessLayer = Camera.main.GetComponent<PostProcessLayer>();
    }

    public void CallMenu()
    {
        isMenuOpen = !isMenuOpen;

        postProcessLayer.enabled = !postProcessLayer.enabled; 
        
        menu.alpha = 1f - menu.alpha;
        menu.blocksRaycasts = isMenuOpen;

        OnControlMenuChanged?.Invoke(isMenuOpen);
    }
}
