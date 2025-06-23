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

    private void OnToggle(InputAction.CallbackContext context) => Toggle();

    private void OnClose(InputAction.CallbackContext context) => Close();

    private void Toggle()
    {
        if (isInventoryOpen) 
            Close();
        else
            Open();
    }
    
    private void Close()
    {
        inputManager.SwitchToPlayer();

        CloseUI();
        SFXAudioManager.Instance.PlaySound("InventoryClose");
    }

    private void Open()
    {
        inputManager.SwitchToInventory();

        OpenUI();
        SFXAudioManager.Instance.PlaySound("InventoryOpen");
    }

    public void OpenUI()
    {
        rectTransform.anchoredPosition = new Vector2(0f, Screen.height * rateOffsetSlide);
        Animate(openPositionSlide, 1f);
        
        isInventoryOpen = true;
    }

    public void CloseUI()
    {
        rectTransform.anchoredPosition = new Vector2(0f, 0f);
        Animate(closePositionSlide, 0f);
        
        isInventoryOpen = false;
    }

    private void Animate(Vector2 slidePosition, float endValue)
    {
        var seq = DOTween.Sequence();
        
        seq.Append(rectTransform.DOAnchorPos(slidePosition, durationSlide).SetEase(Ease.OutCubic));
        seq.Join(canvasGroup.DOFade(endValue, durationFade));
    }
}