using TMPro;
using UnityEngine;

public class LoadingDots : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI loadingText;
    [SerializeField] private float interval = 0.5f;

    private float timer;
    private int dotCount;
    
    private void Update()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f;
            dotCount = (dotCount + 1) % 4;

            string dots = new string('.', dotCount);
            loadingText.text = "Loading" + dots;
        }
    }
}
