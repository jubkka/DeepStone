using TMPro;
using UnityEngine;

public class DefenceView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;

    public void Init(DefenceComponent component)
    {
        tmp.text = Mathf.FloorToInt(component.PhysicalDef).ToString();
        
        component.OnPhysicalDefenceChanged += UpdateText;
    }

    private void UpdateText(float value)
    {
        tmp.text = Mathf.FloorToInt(value).ToString();
    }
}