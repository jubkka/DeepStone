using UnityEngine;

public class CharacterCreation : MonoBehaviour
{
    [Header("UI elements")]
    [SerializeField] private OriginsUI originsUI;

    private void Start() => Subscribe();

    private void Subscribe()
    {
        originsUI.OnOriginSelected += PlayerSetup.Instance.SelectOrigin;
    }
}
