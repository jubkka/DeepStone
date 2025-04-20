using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttributeUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private CharacterList characterList;
    [SerializeField] private TextMeshProUGUI tmp;
    
    public AttributeType AttributeType;

    private void Start()
    {
        characterList.attributeSystem.SubscribeAttribute(AttributeType, this);
    }

    public void UpdateValue(int value)
    {
        tmp.text = value.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        characterList.AttributeIncrease(AttributeType);
    }
}
