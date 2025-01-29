using UnityEngine;
using UnityEngine.UI;

public class WindowActions : MonoBehaviour
{
    [SerializeField] private Button useButton;
    [SerializeField] private Button dropButton;

    public void ShowWindowActions(ItemView itemView) 
    {
        gameObject.SetActive(true);
        transform.position = itemView.transform.position;

        useButton.onClick.RemoveAllListeners();
        dropButton.onClick.RemoveAllListeners();

        useButton.onClick.AddListener(itemView.Use);
        dropButton.onClick.AddListener(itemView.Drop);
    }
}