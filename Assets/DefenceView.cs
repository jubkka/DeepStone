using TMPro;
using UnityEngine;

public class DefenceView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;

    private int defence;

    public void Init(DefenceComponent component)
    {
        tmp.text = Mathf.FloorToInt(component.PhysicalDef).ToString();
        
        Subscribe(component);
    }

    private void Subscribe(DefenceComponent component) => component.OnPhysicalDefenceChanged += UpdateText;

    private void UpdateText(float value)
    {
        tmp.text = Mathf.FloorToInt(value).ToString();
    }
}