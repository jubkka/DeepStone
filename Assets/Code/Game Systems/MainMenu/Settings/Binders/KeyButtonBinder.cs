using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class KeyButtonBinder : Binder
{
    [Header("UI Elements")]
    [SerializeField] private Button button; 
    [SerializeField] private TextMeshProUGUI keyTMP;
    
    [Header("Input action")]
    [SerializeField] private string actionName;
    [SerializeField] private int indexKey;
    
    private InputAction action;
    
    protected override void LoadSetting()
    {
        UpdateButtonText(action.bindings[indexKey].effectivePath);
    }

    protected override void Setup()
    {
        action = InputManager.Controls.FindAction(actionName);
        button.onClick.AddListener(RebindKey);
    }

    private void RebindKey()
    {
        WaitPressButton();
            
        action.Disable();

        action.PerformInteractiveRebinding(indexKey)
            .WithControlsExcluding("Mouse")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(op =>
            {
                op.Dispose();
                action.Enable();
                
                UpdateButtonText(action.bindings[indexKey].effectivePath);
            })
            .Start();
    }

    private void WaitPressButton()
    {
        keyTMP.text = "...";
    }

    private void UpdateButtonText(string nameKey)
    {
        nameKey = nameKey.Split("/")[1];
        keyTMP.text = nameKey.ToUpper();
    }
}