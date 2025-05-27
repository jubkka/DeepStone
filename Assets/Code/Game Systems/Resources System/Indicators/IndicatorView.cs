using TMPro;
using UnityEngine;

public class IndicatorView : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textTMP;
    [SerializeField] protected SliderControl sliderControl;

    public void ChangeSliderValue(float current, float max) 
    { 
        int currentInt = Mathf.FloorToInt(current);
        int maxInt = Mathf.FloorToInt(max);
        
        textTMP.text = currentInt + "/" + maxInt;
        
        sliderControl.SetValue(currentInt);
    }

    public void ChangeSliderValueMax(float max)
    {
        sliderControl.SetMax(max);
    }

    public void Init(float current, float max)
    {
        ChangeSliderValue(current, max);
        ChangeSliderValueMax(max);
    }
}