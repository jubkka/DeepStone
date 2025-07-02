using System.Collections;
using DG.Tweening;
using UnityEngine;

public class EnemyIndicatorView : IndicatorView
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private float timeToDisappear = 1f;
    [SerializeField] private float fadeDuration = 0.5f;

    [SerializeField] private CanvasGroup canvasGroup;

    private Coroutine disappearRoutine;
    private bool isShown = false;

    public void Init()
    {
        textTMP.text = enemy.Data.GetName;
    }

    private void OnEnable() => StartCoroutine(AutoHideAfterDelay());

    private void OnDestroy()
    {
        StopAllCoroutines();
        canvasGroup?.DOKill();
    }

    protected override void ChangeText(int currentInt, int maxInt) { }

    private void Update()
    {
        if (enemy.PlayerCamera == null)
            return;
        
        if (isShown)
            transform.LookAt(enemy.PlayerCamera.transform); 
    }

    public void ToggleIndicator(bool state)
    {
        isShown = state;

        canvasGroup.DOFade(state ? 1f : 0f, fadeDuration);
        enabled = state;

        if (state)
        {
            if (disappearRoutine != null)
                StopCoroutine(disappearRoutine);

            disappearRoutine = StartCoroutine(AutoHideAfterDelay());
        }
        else
        {
            if (disappearRoutine != null)
            {
                StopCoroutine(disappearRoutine);
                disappearRoutine = null;
            }
        }
    }

    private IEnumerator AutoHideAfterDelay()
    {
        yield return new WaitForSeconds(timeToDisappear);
        ToggleIndicator(false);
    }
}