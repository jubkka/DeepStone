using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SlotHoverHandler : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Animator animator;
    
    [SerializeField] private float duration;

    private void Start() => HideActiveSlot();
    
    public void MoveActiveSlot(Transform slots,int indexSlot)
    {
        transform.SetParent(slots.GetChild(indexSlot));
        transform.position = slots.GetChild(indexSlot).position;
        transform.SetSiblingIndex(transform.childCount - 1);
        
        DoFade(1f);
    }

    public void HideActiveSlot()
    {
        DoFade(0f);
    }

    private void DoFade(float endValue)
    {
        if (endValue == 0f)
            animator.enabled = false;
        
        image.DOFade(endValue, duration).OnComplete(
            () => animator.enabled = true
        );
    }
}
