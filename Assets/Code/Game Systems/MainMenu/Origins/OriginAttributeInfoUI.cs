using TMPro;
using UnityEngine;

public class OriginAttributeInfoUI : MonoBehaviour
{
    [SerializeField] private AttributeType attributeType;
    [SerializeField] private OriginsUI originsUI;
    [SerializeField] private TextMeshProUGUI textTMP;

    private void Awake() => originsUI.OnOriginSelected += UpdateText;
    
    private void UpdateText(Origin origin)
    {
        Attribute attribute = origin.GetAttributesData.GetAttribute(attributeType);
        textTMP.text = attribute.Value.ToString();
    }
}
