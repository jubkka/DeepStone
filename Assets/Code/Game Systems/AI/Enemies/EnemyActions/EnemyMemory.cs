using System;
using System.Collections;
using UnityEngine;

public class EnemyMemory : MonoBehaviour
{
    [Header("Enemy")] 
    [SerializeField] private Enemy enemy;
    
    [Header("Memory Settings")]
    [SerializeField] private float secondsForgetDelay;
    
    private Coroutine coroutine;
    public event Action OnPlayerLost;

    private void Start()
    {
        enemy.Vision.OnPlayerDetected += ResetForgetDelay;
        enemy.Vision.OnPlayerLost += StartForgetDelay;
        enemy.Health.OnTakeDamage += StartForgetDelay;
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