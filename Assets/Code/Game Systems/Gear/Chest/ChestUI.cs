using UnityEngine;

public class ChestUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    
    public void Show()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void Hide()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.blocksRaycasts = false;
    }
}