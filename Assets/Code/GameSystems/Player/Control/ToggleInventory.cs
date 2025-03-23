using System;
using UnityEngine;

public class ToggleInventory : MonoBehaviour
{
    [SerializeField] private CanvasGroup inventory;
    public event Action<bool> OnToogleChanged;

    private void Start()
    {
        InputManager.Instance.OnInventoryPressed += Toggle; 
    }

    public void Toggle() 
    {
        bool isInventoryOpen = inventory.alpha == 0;

        inventory.alpha = isInventoryOpen ? 1f : 0f;

        OnToogleChanged?.Invoke(isInventoryOpen);
    } 
}