using TMPro;
using UnityEngine;

public class OriginAttributeInfoUI : MonoBehaviour
{
    [SerializeField] private AttributeType attributeType;
    [SerializeField] private OriginInfoUI originInfoUI;
    [SerializeField] private TextMeshProUGUI textTMP;

    private void Awake() => originInfoUI.OnOriginSelected += UpdateText;
    
    private void UpdateText(Origin origin)
    {
        Attribute attribute = origin.GetAttributeSystem.GetAttribute(attributeType);
        textTMP.text = attribute.Value.ToString();
    }
}
