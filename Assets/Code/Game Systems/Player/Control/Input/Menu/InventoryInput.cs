using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryInput : InputControl
{
    [SerializeField] private GameObject gearUI;
    
    [Header("Slide-In")]
    [SerializeField] private float durationSlide = 0.25f;
    [SerializeField] private float rateOffsetSlide = 0.25f;
    [SerializeField] private Vector2 closePositionSlide = new (0f, 270f);
    [SerializeField] private Vector2 openPositionSlide = Vector2.zero;
    
    [Header("Fade-In")]
    [SerializeField] private float durationFade = 0.25f;
    
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    
    private bool isInventoryOpen = false;
    
    protected override void SubscribeToControls()
    {
        controls.Player.ToggleInventory.performed += OnToggle;
        controls.Inventory.Close.performed += OnClose;
        
        controls.Player.ToggleInventory.Enable();
        controls.Inventory.Enable();
    }
    
    protected override void UnsubscribeFromControls()
    {
        controls.Player.ToggleInventory.performed -= OnToggle;
        controls.Inventory.Close.performed -= OnClose;
        
        controls.Player.ToggleInventory.Disable();
        controls.Inventory.Disable();
    }

    private void Awake()
    {
        rectTransform = gearUI.GetComponent<RectTransform>();
        canvasGroup = gearUI.GetComponent<CanvasGroup>();
    }

    private void OnToggle(InputAction.CallbackContext context)
    {
        Toggle();
    }
    
    private void OnClose(InputAction.CallbackContext context)
    {
        isInventoryOpen = false;
        
        Close();
    }

    public void Toggle()
    {
        if (isInventoryOpen)
            Close();
        else
            Open();
        
        isInventoryOpen = !isInventoryOpen;
    }
    
    private void Close()
    {
        inputManager.SwitchToPlayer();
        
        var seq = DOTween.Sequence(); //TODO
        
        rectTransform.anchoredPosition = new Vector2(0f, 0f);
        
        Animate(closePositionSlide, 0f);
    }

    private void Open()
    {
        inputManager.SwitchToInventory();
        
        rectTransform.anchoredPosition = new Vector2(0f, Screen.height * rateOffsetSlide);
        
        Animate(openPositionSlide, 1f);
    }

    private void Animate(Vector2 slidePosition, float endValue)
    {
        var seq = DOTween.Sequence();
        
        seq.Append(rectTransform.DOAnchorPos(slidePosition, durationSlide).SetEase(Ease.OutCubic));
        seq.Join(canvasGroup.DOFade(endValue, durationFade));
    }
}