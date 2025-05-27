using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    [SerializeField] private float duration;
    
    [Header("Sliders")]
    [SerializeField] protected Slider barSlider;
    [SerializeField] protected Slider brightSlider;

    public void SetValue(int current)
    {
        barSlider.DOKill();
        brightSlider.DOKill();

        if (barSlider.value > current)
        {
            barSlider.value = current;
            brightSlider.DOValue(current, duration).SetEase(Ease.InQuad).SetDelay(0.25f);  
        }
        else
        {
            brightSlider.value = current;
            barSlider.DOValue(current, duration).SetEase(Ease.InQuad).SetDelay(0.25f);   
        }
    }

    public void SetMax(float max)
    {
        barSlider.maxValue = max;
        brightSlider.maxValue = max;
    }
}