using DG.Tweening;
using TMPro;
using UnityEngine;

public class InfoPanelWorldSpace : MonoBehaviour
{
    [SerializeField] private float doFadeDuration;
    
    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI nameItem;
    [SerializeField] private TextMeshProUGUI costItem;
    [SerializeField] private TextMeshProUGUI weightItem;
    
    private Camera cam;
    private CanvasGroup canvasGroup;
    
    private bool isVisible = false;

    public bool IsVisible => isVisible;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        cam = Camera.main;
        
        transform.localScale = new Vector3(-0.01f, 0.01f, 0.01f);
    }

    public void SetData(GenericElementData data)
    {
        ItemData newData = (ItemData)data; 
        
        nameItem.text = newData.name;
        costItem.text = $"<sprite name=\"coin\"> {newData.GetCost}";
        weightItem.text = $"<sprite name=\"weight\"> {newData.GetWeight}";
    }

    private void Update()
    {
        if (isVisible)
            transform.LookAt(cam?.transform);
    }

    public InfoPanelWorldSpace Show()
    {
        canvasGroup.DOFade(1f, doFadeDuration);
        isVisible = true;
        
        return this;
    }
    
    public void Hide()
    {
        canvasGroup.DOFade(0f, doFadeDuration);
        isVisible = false;
    }
}
