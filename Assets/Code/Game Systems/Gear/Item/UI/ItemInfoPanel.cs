using DG.Tweening;
using TMPro;
using UnityEngine;

public class ItemInfoPanel : MonoBehaviour
{
    [SerializeField] float duration;
    [SerializeField] private Vector2 offset;
    
    [Header("TMPs")]
    [SerializeField] TextMeshProUGUI nameTMP;
    [SerializeField] TextMeshProUGUI descriptionTMP;
    [SerializeField] TextMeshProUGUI costTMP;
    [SerializeField] TextMeshProUGUI weightTMP;
    
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        FollowCursor();
    }

    private void FollowCursor()
    {
        if (canvasGroup.alpha > 0f)
        {
            Vector3 pos = Input.mousePosition;

            if (pos.y < Screen.height * 0.1f)
                rectTransform.pivot = Vector2.zero;
            else
                rectTransform.pivot = offset;
            
            transform.position = pos;
        }
    }

    public void ToggleItemInfo(GearComponent gear, int indexSlot) 
    {
        Item item = gear.GetItem(indexSlot);

        if (item.data is IInfoDisplayable data) 
        {
            SetInfo(data);
            DoFadePanel(1f);
        }
    }

    private void SetInfo(IInfoDisplayable data) 
    {
        nameTMP.text = data.GetNameString;
        descriptionTMP.text = data.GetDescriptionString;
        costTMP.text = data.GetCostString;
        weightTMP.text = data.GetWeightString;
    }

    public void DoFadePanel(float value) 
    {
        canvasGroup.DOFade(value, duration);
    }
}
