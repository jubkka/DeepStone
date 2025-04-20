using UnityEngine;
using UnityEngine.UI;

public class ExperienceView : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponentInChildren<Slider>();
    }

    public void UpdateExperience(int amount)
    {
        slider.value = amount;
    }

    public void UpdateCountExpToNextLevel(int amount)
    {
        slider.maxValue = amount;
    }
}