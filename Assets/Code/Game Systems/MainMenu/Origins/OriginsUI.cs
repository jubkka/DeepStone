using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OriginsUI : MonoBehaviour
{
    [SerializeField] private List<Origin> origins;
    
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Transform content;
    [SerializeField] private GameObject cover;
    [SerializeField] private Button startButton;
    
    public event Action<Origin> OnOriginSelected;

    private void Awake() => AddOrigins();
    
    private void AddOrigins()
    {
        foreach (var origin in origins)
            AddButton(origin);
    }

    private void AddButton(Origin origin)
    {
        Button button = Instantiate(buttonPrefab, content).GetComponent<Button>();
        TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();
        
        text.text = origin.name;
        
        button.onClick.AddListener(() => AddInfo(origin));
        button.onClick.AddListener(() => cover.SetActive(false));
        button.onClick.AddListener(() => startButton.interactable = true);
    }
    
    private void AddInfo(Origin origin) => OnOriginSelected?.Invoke(origin);
}
