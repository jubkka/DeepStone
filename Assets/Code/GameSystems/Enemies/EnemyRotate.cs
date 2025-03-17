using System.Collections;
using UnityEngine;

public class EnemyRotate : MonoBehaviour
{
    private Transform enemy;
    private Coroutine coroutine;

    private void Start()
    {
        enemy = transform.parent.parent;
    }

    public void StartRotate(float angle, float duration) 
    {
        if (coroutine == null)
           coroutine = StartCoroutine(RotateSmoothly(angle, duration));
    }

    private IEnumerator RotateSmoothly(float targetAngle, float duration) 
    {
        Quaternion startRotation = enemy.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(0, startRotation.eulerAngles.y + targetAngle, 0);
        float timeElapsed = 0f;

        while (timeElapsed < duration) 
        {
            enemy.transform.rotation = Quaternion.Lerp(startRotation, endRotation, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        enemy.transform.rotation = endRotation;
        coroutine = null;
    }
}