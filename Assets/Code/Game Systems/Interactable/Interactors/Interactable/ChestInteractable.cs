using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChestInteractable : Interactable
{
    [SerializeField] private InventoryInput inventoryInput;
    [SerializeField] private CanvasGroup canvasGroup;
    
    private ChestComponent chest;
    private ChestContainer chestContainer;
    private Animation anim;
    
    private InputManager inputManager;
    private PlayerControls controls;
    
    private bool isOpen = false;

    private void Awake()
    {
        inputManager = InputManager.instance;
        controls = inputManager.controls;
    }
    
    private void Start()
    {
        chest = GearSystems.Instance.Chest;
        
        anim = GetComponentInParent<Animation>();
        chestContainer = GetComponent<ChestContainer>();
    }

    private void OnEnable()
    {
        controls.Chest.Close.performed += OnClose;
        controls.Chest.Enable();
    }

    private void OnDisable()
    {
        controls.Chest.Close.performed -= OnClose;
        controls.Chest.Disable();
    }

    private void OnClose(InputAction.CallbackContext context)
    {
        Close();
    }
    
    public override void Interact()
    {
        Open();
    }

    private void Open()
    {
        inventoryInput.Toggle();
        
        ChangeState(true);
        chest.GiveItems(chestContainer.Items);
        //anim.Play("Opening");
        
        inputManager.SwitchToChest();
    }

    private void Close()
    {
        if (!isOpen)
            return;
        
        inventoryInput.Toggle();
        
        ChangeState(false);
        chestContainer.Items = chest.TakeItems();
        //anim.Play("Closing");
    }

    private void ChangeState(bool state)
    {
        canvasGroup.alpha = state ? 1f : 0f;
        canvasGroup.blocksRaycasts = canvasGroup.alpha == 1f;
        isOpen = state;
    }
}