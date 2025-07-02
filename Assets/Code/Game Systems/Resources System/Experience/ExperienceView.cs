using TMPro;
using UnityEngine;
using DG.Tweening;

public class ExperienceView : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TextMeshProUGUI expInFrame;
    [SerializeField] private TextMeshProUGUI gainedExp;
    [SerializeField] private SliderControl slider;

    [Header("Animation")] 
    [SerializeField] private float duration;
    [SerializeField] private float strength;
    [SerializeField] private int vibrato;

    private int current;
    private int nextLevel;

    private Vector3 originalPosition;

    public void Init(LevelComponent levelComponent)
    {
        current = levelComponent.Exp;
        nextLevel = levelComponent.ExpToNextLevel;

        expInFrame.text = $"{current} / {nextLevel}";
        originalPosition = expInFrame.transform.localPosition;

        Subscribe(levelComponent);
    }

    private void Subscribe(LevelComponent levelComponent)
    {
        levelComponent.OnExpChanged += UpdateExp;
        levelComponent.OnExpGained += UpdateGainedExp;
        levelComponent.OnExpToNextLevelChanged += UpdateExpToNextLevel;
    }

    private void UpdateExp(int newCurrent)
    {
        current = newCurrent;
        slider.SetValue(newCurrent);
        UpdateText();
    }

    private void UpdateGainedExp(int newGained)
    {
        gainedExp.text = $"+{newGained} EXP";
        AnimGainedExp();
    }

    private void UpdateExpToNextLevel(int newValue)
    {
        nextLevel = newValue;
        slider.SetMax(newValue);
        UpdateText();
    }

    private void UpdateText()
    {
        expInFrame.text = $"{current} / {nextLevel}";
        AnimateExpText();
    }

    private void AnimateExpText()
    {
        expInFrame.transform.DOKill();
        expInFrame.transform.localPosition = originalPosition;

        expInFrame.transform
            .DOShakePosition(duration, strength, vibrato)
            .OnComplete(() => expInFrame.transform.localPosition = originalPosition);
    }

    private void AnimGainedExp()
    {
        gainedExp.DOKill();
        gainedExp.DOFade(1f, 0f);
        gainedExp.DOFade(0f, 1.5f).SetDelay(1f);
    }
}
