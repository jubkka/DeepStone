using System.Collections;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class LevelUpView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;
    [SerializeField] private float moveUpDistance = 100f;
    [SerializeField] private float duration = 1.5f;
    [SerializeField] private float scaleUp = 1.3f;

    private Vector3 startPosition;
    private Vector3 startScale;

    public void Init(LevelComponent level)
    {
        level.OnLevelUp += Show;
        
        startPosition = tmp.rectTransform.anchoredPosition;
        startScale = tmp.rectTransform.localScale;
    }

    private void Show(int level)
    {
        tmp.text = $"Level UP {level}";
        tmp.gameObject.SetActive(true);
        tmp.color = new Color(tmp.color.r, tmp.color.g, tmp.color.b, 1f);
        
        tmp.rectTransform.anchoredPosition = startPosition;
        tmp.rectTransform.localScale = startScale;

        Sequence seq = DOTween.Sequence();

        seq.Append(tmp.rectTransform.DOScale(scaleUp, 0.3f).SetEase(Ease.OutBack))
            .Join(tmp.rectTransform.DOAnchorPosY(startPosition.y + moveUpDistance, duration).SetEase(Ease.OutQuad))
            .Join(tmp.DOFade(0f, duration).SetEase(Ease.InQuad))
            .AppendCallback(() => tmp.gameObject.SetActive(false));
    }
}