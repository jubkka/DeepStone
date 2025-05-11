using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class EnemyIndicatorView : IndicatorView
{
    [SerializeField] private float timeToDisappear = 1f;
    private CanvasGroup canvasGroup;

    protected void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();

       transform.localScale = new Vector3(
           -transform.localScale.x, 
           transform.localScale.y, 
           transform.localScale.z);
    }

    private void OnEnable() => StartCoroutine(TimerToDisappear());

    private void Update()
    {
        transform.LookAt(Camera.main.transform);
    }

    public void ToggleIndicator(bool state)
    {
        float alpha = state ? 1f : 0f;
        canvasGroup.DOFade(alpha, 0.5f);
        enabled = state;
    }

    private IEnumerator TimerToDisappear()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToDisappear);
            ToggleIndicator(false);
        }
    }
}