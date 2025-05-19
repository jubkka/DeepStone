using System;
using System.Collections;
using UnityEngine;

public class EnemyMemory : MonoBehaviour
{
    [SerializeField] private float secondsForgetDelay;
    
    [SerializeField] private EnemyVision vision;
    [SerializeField] private EnemyHealth health;
    
    private Coroutine coroutine;

    public event Action OnPlayerLost;

    private void Start()
    {
        vision.OnPlayerDetected += ResetForgetDelay;
        vision.OnPlayerLost += StartForgetDelay;
        health.OnTakeDamage += StartForgetDelay;
    }

    private void StartForgetDelay()
    {
        if (coroutine == null)
        {
            coroutine = StartCoroutine(ForgetPlayerDelay());
        }
        else
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    private void ResetForgetDelay()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    private IEnumerator ForgetPlayerDelay()
    {
        yield return new WaitForSeconds(secondsForgetDelay);
        
        coroutine = null;
        OnPlayerLost?.Invoke();
    }
}