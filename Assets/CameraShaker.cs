using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] private float shakeAmplitude = 0.02f;
    [SerializeField] private float shakeSpeed = 5f;
    
    private Vector3 originalPosition;
    private bool isShaking;
    private float offsetTimer;

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    public void StartShaking()
    {
        isShaking = true;
    }

    public void StopShaking()
    {
        isShaking = false;
        transform.localPosition = originalPosition;
    }

    private void Update()
    {
        if (!isShaking) 
            return;

        offsetTimer += Time.deltaTime * shakeSpeed;

        float raw = Mathf.PingPong(offsetTimer, 1f);
        float offsetY = (raw - 0.5f) * 2f * shakeAmplitude;

        transform.localPosition = originalPosition + new Vector3(0f, offsetY, 0f);
    }
}
