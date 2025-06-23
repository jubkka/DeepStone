using TMPro;
using UnityEngine;

public class AttackView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;
    
    public void UpdateText(int value)
    {
        tmp.text = value.ToString();
    }
}