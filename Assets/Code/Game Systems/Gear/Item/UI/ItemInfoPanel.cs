using DG.Tweening;
using TMPro;
using UnityEngine;

public class ItemInfoPanel : MonoBehaviour
{
    [SerializeField] float duration;
    [SerializeField] private Vector2 offset;
    
    [Header("ItemTemplateManager")]
    [SerializeField] ItemTemplateManager templateManager;
    
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

        if (item.data is IInfoDisplayable  data) 
        {
            SetInfo(data);
            DoFadePanel(1f);
        }
    }

    private void SetInfo(IInfoDisplayable  data) 
    {
        var (nameData, weight, cost,description, alignment) = templateManager.GetFormattedDescription(data);
        
        nameTMP.text = nameData;
        descriptionTMP.text = description;
        descriptionTMP.alignment = alignment;
        costTMP.text = cost;
        weightTMP.text = weight;
    }

    public void DoFadePanel(float value) 
    {
        canvasGroup.DOFade(value, duration);
    }
}
