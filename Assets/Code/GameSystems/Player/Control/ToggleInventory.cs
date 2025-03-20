using System;
using UnityEngine;

public class ToggleInventory : MonoBehaviour
{
    [SerializeField] private CanvasGroup inventory;
    [SerializeField] private CanvasGroup chest;
    private PlayerRotate playerRotate;
    private PlayerMovement playerMovement;
    private KeyCode toggleInventory;

    private void Awake()
    {
        toggleInventory = KeysManager.GetKey("ToggleInventory");
        playerRotate = GetComponent<PlayerRotate>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(toggleInventory)) Toggle();
    }

    //Переделать функцию
    public void Toggle() 
    {
        bool isInventoryOpen = inventory.alpha == 0;

        inventory.alpha = isInventoryOpen ? 1f : 0f;
        chest.alpha = inventory.alpha;

        playerRotate.enabled = !isInventoryOpen;
        playerMovement.enabled = !isInventoryOpen;

        Cursor.visible = isInventoryOpen;
        Cursor.lockState = isInventoryOpen ? CursorLockMode.None : CursorLockMode.Locked;
    } 
}