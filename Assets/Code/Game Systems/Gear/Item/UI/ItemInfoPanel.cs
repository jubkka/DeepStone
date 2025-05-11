using DG.Tweening;
using TMPro;
using UnityEngine;

public class ItemInfoPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameTMP;
    [SerializeField] TextMeshProUGUI desriptionTMP;
    [SerializeField] TextMeshProUGUI costTMP;
    [SerializeField] TextMeshProUGUI weightTMP;
    [SerializeField] float duration;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void ToggleItemInfo(GearComponent gear, int indexSlot) 
    {
        Item item = gear.GetItem(indexSlot);

        if (item.data != null) 
        {
            SetInfo(item);
            DoFadePanel(1f);
        }
    }

    private void SetInfo(Item item) 
    {
        nameTMP.text = item.data.GetItemName;
    }

    public void DoFadePanel(float value) 
    {
        canvasGroup.DOFade(value, duration);
    }
}
