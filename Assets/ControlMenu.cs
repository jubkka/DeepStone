using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ControlMenu : MonoBehaviour
{
    [SerializeField] private GameObject controlPlayer;
    [SerializeField] private CanvasGroup menu;
    private bool isMenuOpen = false;

    private void Update()
    {
        CallMenu(false);
    }

    public void CallMenu(bool isClick)
    {
        if (!Input.GetKeyDown(KeysManager.GetKey("CallMenu")) && !isClick) return;

        isMenuOpen = !isMenuOpen;

        PostProcessLayer postProcessLayer = Camera.main.GetComponent<PostProcessLayer>();

        postProcessLayer.enabled = !postProcessLayer.enabled; 
        controlPlayer.SetActive(!controlPlayer.activeSelf);
        menu.alpha = 1f - menu.alpha;

        ControlCursor.ChangeStateCursor(isMenuOpen);
    }
}
