using System;
using UnityEngine;

public class HotbarInputControl : MonoBehaviour
{
    [SerializeField] private HotbarComponent hotbar;
    private int activeSlot;
    private Item activeItem;
    public Item GetActiveItem => activeItem;
    public int GetActiveSlot => activeSlot;
    public event Action<int> OnActiveSlotChanged;
    public event Action OnItemChanged;

    private void Update()
    {
        ScrollMouse();
        SelectHotbarSlot();
    }
    private void SelectHotbarSlot()
    {
        if (Input.anyKeyDown) 
        {
            for (int i = 0; i < KeysManager.GetKeyCodesHotbar.Count; i++)
            {
                if (Input.GetKeyDown(KeysManager.GetKeyCodesHotbar[i])) 
                {
                    activeSlot = i;
                }
            }
        }

        OnChanged();
    }
    private void ScrollMouse()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0f) 
        {
            activeSlot = activeSlot != 8 ? activeSlot + 1 : 0;
        }
        else if (scroll < 0f)
        {
            activeSlot = activeSlot != 0 ? activeSlot - 1 : 8;
        }

        OnChanged();
    }
    private void OnChanged()
    {
        OnItemChanged?.Invoke();
        OnActiveSlotChanged?.Invoke(activeSlot);
        activeItem = hotbar.GetItem(activeSlot);
    }
}
