using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class AttributeUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI tmp;
    [SerializeField] private AttributeType attributeType;

    private AttributeComponent attribute;

    public void Init(AttributeComponent attributeComponent)
    {
        attribute = attributeComponent;
        
        SubscribeAttribute();
    }

    private void UpdateValue(int value)
    {
        tmp.text = value.ToString();
        Animate();
    }

    private void Animate()
    {
        var seq = DOTween.Sequence();
        
        seq.Append(tmp.transform.DOShakePosition(0.5f, strength: 5f, vibrato: 10));
        //seq.Join(tmp.DOColor(new Color32(90, 197, 79, 255), 0.5f).SetLoops(2, LoopType.Yoyo));
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        attribute.AttributeIncrease(attributeType);
    }

    private void SubscribeAttribute()
    {
        var attr = attribute.GetAttribute(attributeType);

        if (attr != null)
        {
            attr.OnAttributeChanged += UpdateValue;
            
            tmp.text = attr.Value.ToString();
        }
    }
}
