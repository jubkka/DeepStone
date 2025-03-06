using UnityEngine;

public class ToggleInventory : MonoBehaviour
{
    [SerializeField] private CanvasGroup inventory;
    private PlayerRotate playerRotate;
    private PlayerMovement playerMovement;

    private KeyCode toggleInventory;

    private void Awake()
    {
        toggleInventory = InputManager.GetKey("ToggleInventory");
        playerRotate = GetComponent<PlayerRotate>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(toggleInventory)) Toggle();
    }

    private void Toggle() 
    {
        bool isInventoryOpen = inventory.alpha == 0;

        inventory.alpha = isInventoryOpen ? 1f : 0f;
        playerRotate.enabled = !isInventoryOpen;
        playerMovement.enabled = !isInventoryOpen;

        Cursor.visible = isInventoryOpen;
        Cursor.lockState = isInventoryOpen ? CursorLockMode.None : CursorLockMode.Locked;
    } 
}