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

    public void Init(LevelComponent levelComponent)
    {
        current = levelComponent.Exp;
        nextLevel = levelComponent.ExpToNextLevel;
        
        expInFrame.text = $"{current} / {nextLevel}";
        
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
        gainedExp.text = $"+{newGained}";
        
        Anim();
    }

    private void UpdateExpToNextLevel(int newValue)
    {
        nextLevel = newValue;
        slider.SetMax(newValue);
        
        UpdateText();
    }

    private void Anim()
    {
        gainedExp.DOKill();
        
        gainedExp.DOFade(1f, 0f);
        gainedExp.DOFade(0f, 1.5f).SetDelay(1f);
    }

    private void UpdateText()
    {
        expInFrame.text = $"{current} / {nextLevel}";

        Animate();
    }

    private void Animate()
    {
        expInFrame.transform.DOShakePosition(duration, strength: strength, vibrato: vibrato);
    }
}