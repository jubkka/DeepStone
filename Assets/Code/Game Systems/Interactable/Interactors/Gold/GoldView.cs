using TMPro;
using UnityEngine;

public class GoldView : MonoBehaviour 
{
    [SerializeField] private TextMeshProUGUI textTMP;
    
    public void ChangeText(int count)
    {
        textTMP.text = count.ToString();
    }
}