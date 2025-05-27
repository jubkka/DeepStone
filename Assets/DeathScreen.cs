using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private Canvas UI;
    private CanvasGroup[] otherCanvas;

    private CanvasGroup deathScreen;

    private void Start()
    {
        otherCanvas = GetComponentsInParent<CanvasGroup>();
        deathScreen = GetComponent<CanvasGroup>();
    }

    public void Show()
    {
        foreach (var canvas in otherCanvas)
            canvas.alpha = 0;
        
        deathScreen.alpha = 1;
    }
}
