using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttributeUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI tmp;
    [SerializeField] private AttributeType attributeType;
    
    private AttributeComponent attributeComponent;

    private void Start()
    {
        attributeComponent = CharacterStatsSystems.Instance.GetAttribute;
        attributeComponent.SubscribeAttribute(attributeType, this);
    }

    public void UpdateValue(int value)
    {
        tmp.text = value.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        attributeComponent.AttributeIncrease(attributeType);
    }
}
