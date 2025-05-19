using DG.Tweening;
using UnityEngine;

public class InfoPanelWorldSpace : MonoBehaviour
{
    [SerializeField] private float doFadeDuration;
    
    private Camera cam;
    private CanvasGroup canvasGroup;
    private bool isVisible;

    public bool IsVisible => isVisible;

    private void Start()
    {
        cam = Camera.main;
        canvasGroup = GetComponent<CanvasGroup>();
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
