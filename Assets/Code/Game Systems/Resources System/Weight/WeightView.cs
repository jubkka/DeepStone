using TMPro;
using UnityEngine;

public class WeightView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TMP;
    private Color colorOverlimit = new Color(234,50,60);
    
    public void UpdateText(int current, int max)
    {
        TMP.text = current + "/" + max;
    }

    public void SetColorOverlimit(bool overlimit)
    {
        TMP.color = overlimit ? colorOverlimit : Color.white;
    }
}