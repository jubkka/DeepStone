using UnityEngine;

public class InfoPanelManager : MonoBehaviour
{
    private InfoPanelWorldSpace lastInfoPanel;
    
    private Transform cam;
    private float distance;

    private void Start() 
    {
        cam = Camera.main.transform;
        distance = Raycaster.Rays[RaysType.Interact];
    }

    public void Update()
    {
        ShowInfoPanel();
    }

    private void ShowInfoPanel()
    {
        if (!Raycaster.Cast(cam.position, cam.forward, distance, out GameObject target)) 
        {
            if (lastInfoPanel) 
                lastInfoPanel.Hide();

            return;
        }
        
        InfoPanelWorldSpace infoPanel = target?.GetComponentInChildren<InfoPanelWorldSpace>();
        
        if (infoPanel == null)
            return;
        
        if (infoPanel.IsVisible)
            return;

        if (lastInfoPanel && infoPanel != lastInfoPanel)
            lastInfoPanel.Hide();
        
        lastInfoPanel = infoPanel.Show();
    }
}