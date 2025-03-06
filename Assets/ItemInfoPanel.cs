using DG.Tweening;
using UnityEngine;

public class ItemInfoPanel : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    [SerializeField] float duration;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void ToggleItemInfo(GearComponent gear, int indexSlot) 
    {
       if (gear.GetItem(indexSlot).data != null) canvasGroup.DOFade(1f, duration);
       else HideItemInfo();
    }

    public void HideItemInfo() 
    {
        canvasGroup.DOFade(0f, duration);
    }
}
