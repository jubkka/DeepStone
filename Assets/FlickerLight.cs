using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    [SerializeField] private Light torchLight;
    [SerializeField] private float flickerIntensity;
    [SerializeField] private float flickerSpeed;
    
    private float baseIntensity;
    
    private void Start()
    {
        baseIntensity = torchLight.intensity;
    }
    
    private void Update()
    {
        float noise = Mathf.PerlinNoise(Time.time * flickerSpeed, 0f);
        torchLight.intensity = baseIntensity + noise * flickerIntensity;
    }
}
