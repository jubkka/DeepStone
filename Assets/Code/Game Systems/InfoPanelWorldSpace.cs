using DG.Tweening;
using UnityEngine;

public class InfoPanelWorldSpace : MonoBehaviour
{
    [SerializeField] private float doFadeDuration;
    
    private Camera cam;
    private CanvasGroup canvasGroup;

    public bool Visible => canvasGroup.alpha == 1f;

    private void Start()
    {
        cam = Camera.main;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        transform.LookAt(cam.transform);
    }

    public InfoPanelWorldSpace Show()
    {
        canvasGroup.DOFade(1f, doFadeDuration);
        return this;
    }

    public void Hide()
    {
        canvasGroup.DOFade(0f, doFadeDuration);
    }
}
