using TMPro;
using UnityEngine;

public class TextItemHotbar : MonoBehaviour
{
    [Header("Hotbar Component")]
    [SerializeField] private HotbarComponent hotbarComponent;
    [SerializeField] private HotbarInput hotbarInput;
    [SerializeField] private HotbarInputUI hotbarInputUI;
    
    [Header("Text Components")]
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI tmp;
    
    public void Init(HotbarComponent hotbar)
    {
        hotbarComponent = hotbar;
        
        hotbarInput.OnKeyPressed += UpdateText;
        hotbarInputUI.OnMouseScrolled += UpdateText;
    }

    private void UpdateText(int slotIndex)
    {
        Item item = hotbarComponent.GetItem(slotIndex);

        if (item.data == null)
            HideItemName();
        else
            ShowItemName(item);
    }

    private void ShowItemName(Item item)
    {
        tmp.text = item.data.name;
        canvasGroup.alpha = 1f;
    }

    private void HideItemName()
    {
        canvasGroup.alpha = 0f;
    }
}
