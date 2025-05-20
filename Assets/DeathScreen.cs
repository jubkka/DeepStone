using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private Canvas deathScreen;
    private CanvasGroup[] otherCanvas;

    private void Start()
    {
        otherCanvas = GetComponentsInParent<CanvasGroup>();
    }

    public void Show()
    {
        foreach (var canvas in otherCanvas)
            canvas.alpha = 0;
        
        deathScreen.gameObject.SetActive(true);
    }
}
