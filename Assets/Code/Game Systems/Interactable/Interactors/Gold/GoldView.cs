using TMPro;
using UnityEngine;

public class GoldView : MonoBehaviour 
{
    [SerializeField] private TextMeshProUGUI textTMP;
    
    private void Awake()
    {
        GoldModel.OnGoldChanged += ChangeText;
    }
    public void ChangeText(int count)
    {
        textTMP.text = count.ToString();
    }
}