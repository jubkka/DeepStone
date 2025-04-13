using TMPro;
using UnityEngine;

public class FpsCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fpsCounterTMP;
    void Update()
    {
        fpsCounterTMP.text = ((int)(1 / Time.deltaTime)).ToString();
    }
}
