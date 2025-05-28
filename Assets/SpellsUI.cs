using UnityEngine;
using UnityEngine.UI;

public class SpellsUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Button spellButton;
    [SerializeField] private Button inventoryButton;

    public void Open()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        ChangeStateButton(false);
    }

    public void Close()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.blocksRaycasts = false;

        ChangeStateButton(true);
    }

    private void ChangeStateButton(bool state)
    {
        spellButton.gameObject.SetActive(state);
        inventoryButton.gameObject.SetActive(!state);
    }
}
