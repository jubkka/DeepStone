using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EffectView : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Slider slider;

    [SerializeField] private float blinkThreshold = 0.1f;
    [SerializeField] private float minBlinkTime = 1f;
    [SerializeField] private float maxBlinkTime = 3f;
    
    private Tween sliderTween;
    private Tween blinkTween;
    private Tween delayedBlinkCall;
    private Tween delayedDisappearCall;
    private Tween appearTween;
    private Tween disappearTween;
    
    public void Init(Sprite newSprite, float duration)
    {
        if (image is null) return;
        
        image.sprite = newSprite;
        RefreshDuration(duration);
    }
    
    public void RefreshDuration(float newDuration)
    {
        if (slider is null) return;
        
        slider.maxValue = newDuration;
        slider.value = newDuration;
        
        KillTweens();
        PlayAnimation(newDuration);
    }

    private void KillTweens()
    {
        sliderTween?.Kill();
        blinkTween?.Kill();
        delayedBlinkCall?.Kill();
        delayedDisappearCall?.Kill();
        appearTween?.Kill();
        disappearTween?.Kill();
    }

    private void PlayAnimation(float duration)
    {
        float blinkTime = Math.Clamp(duration * blinkThreshold, minBlinkTime, maxBlinkTime);
        float delayBeforeBlink = duration - blinkTime;
        
        PlayAppearAnimation();
        PlaySliderAnimation(duration);
        
        delayedDisappearCall = DOVirtual.DelayedCall(duration, () => {
            if (this != null && gameObject != null)
                PlayDisappearAnimation();
        });
        
        delayedBlinkCall = DOVirtual.DelayedCall(delayBeforeBlink, () => {
            if (this != null && gameObject != null && image != null)
                StartBlinking();
        });
    }

    private void PlaySliderAnimation(float duration)
    {
        if (slider is null) return;
        
        sliderTween?.Kill();
        sliderTween = slider.DOValue(0f, duration).SetEase(Ease.Linear);
    }

    private void PlayAppearAnimation()
    {
        if (image is null) return;
        
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        transform.localScale = Vector3.one * 1.2f;
        
        appearTween?.Kill();
        appearTween = DOTween.Sequence()
            .Append(image.DOFade(1f, 0.4f))
            .Join(transform.DOScale(Vector3.one, 0.4f).SetEase(Ease.OutBounce));
    }

    private void PlayDisappearAnimation()
    {
        if (this == null || gameObject == null || image == null) return;
        
        transform.localScale = Vector3.one * 0.8f;
        
        disappearTween?.Kill();
        disappearTween = DOTween.Sequence()
            .Append(image.DOFade(0f, 0.4f))
            .Join(transform.DOScale(Vector3.zero, 0.4f).SetEase(Ease.OutBounce))
            .OnComplete(() => {
                if (this != null && gameObject != null)
                    Destroy(gameObject);
            });
    }

    private void StartBlinking()
    {
        if (image == null) return;
        
        blinkTween?.Kill();
        blinkTween = image.DOFade(0.5f, 0.3f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.Flash);
    }
    
    private void OnDestroy()
    {
        KillTweens();
    }
}