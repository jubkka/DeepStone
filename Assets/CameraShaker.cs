using DG.Tweening;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] private Transform cameraHolder;
    
    [Header("Movement")]
    [SerializeField] private float movementAmplitude = 0.05f;
    [SerializeField] private float movementDuration = 0.4f;
    
    [Header("Damage")]
    [SerializeField] private float damageDuration = 0.2f;
    [SerializeField] private float damageStrength = 0.5f;
    [SerializeField] private int damageVibrato = 10;
    
    private Tween movementTween;
    private Vector3 originalPosition;
    private bool isShaking;
    private float offsetTimer;

    private void Start()
    {
        originalPosition = cameraHolder.localPosition;
    }

    public void ShakeDamage()
    {
        KillMovement();
        
        cameraHolder.DOComplete();
        cameraHolder.localPosition = originalPosition;
        
        cameraHolder.DOShakePosition(damageDuration, damageStrength, damageVibrato)
            .OnComplete(
                () =>
                {
                    cameraHolder.localPosition = originalPosition;
                });
    }

    public void DecideShake(float magnitude)
    {
        if (magnitude > 0.01f)
            StartShakeMovement();
        else
            StopShakeMovement();
    }

    private void StartShakeMovement()
    {
        if (movementTween != null && movementTween.IsActive())
            return;

        movementTween = cameraHolder
            .DOPunchPosition(Vector3.up * movementAmplitude, movementDuration, 1, 0)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.InOutSine);
    }
    
    private void StopShakeMovement()
    {
        KillMovement();
        cameraHolder.localPosition = originalPosition;
    }

    private void KillMovement()
    {
        if (movementTween != null)
        {
            movementTween.Kill();
            movementTween = null;
        }
    }
}
