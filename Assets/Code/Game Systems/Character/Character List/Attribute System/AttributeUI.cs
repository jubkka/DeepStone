using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttributeUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI tmp;
    [SerializeField] private AttributeType attributeType;
    
    private AttributeComponent attributeComponent;

    public void Init()
    {
        attributeComponent = CharacterStatsSystems.Instance.Attribute;
        SubscribeAttribute();
    }

    private void UpdateValue(int value)
    {
        tmp.text = value.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        attributeComponent.AttributeIncrease(attributeType);
    }

    private void SubscribeAttribute()
    {
        var attribute = attributeComponent.GetAttribute(attributeType);

        if (attribute != null)
        {
            attribute.OnAttributeChanged += UpdateValue;
            UpdateValue(attribute.Value);
            
        }
    }
}
