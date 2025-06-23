using TMPro;
using UnityEngine;

public class RegenerationView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;

    public void Init(IndicatorComponent indicator)
    {
        tmp.text = Mathf.FloorToInt(indicator.RegenerationPercent).ToString();

        indicator.OnRegenerationPercentChanged += UpdateText;
    }

    private void UpdateText(float value)
    {
        tmp.text = value + "%";
    }
}