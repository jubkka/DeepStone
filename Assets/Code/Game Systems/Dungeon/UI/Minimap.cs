using System;
using UnityEngine;
using UnityEngine.UI;

public class Minimap : MonoBehaviour
{
    [SerializeField] private GameObject playerMarker;
    [SerializeField] private RawImage minimapImage;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        UpdateMinimap();
    }

    private void UpdateMinimap()
    {
        //Vector2 playerPos = WorldToMinimapPosition(player.position);
        
        DrawOnMinimap();
    }

    private void DrawOnMinimap()
    {
        ClearMinimap();
        
        Vector2 playerMinimapPosition = WorldToMinimapPosition(player.position);
        Instantiate(playerMarker, playerMinimapPosition, Quaternion.identity, minimapImage.transform);
    }

    private void ClearMinimap()
    {
        foreach (Transform child in minimapImage.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private Vector2 WorldToMinimapPosition(Vector3 worldPos)
    {
        float miniMapX = worldPos.x / 100f * 300f;
        float miniMapZ = worldPos.z / 100f * 300f;
        
        return new Vector2(miniMapX, miniMapZ);
    }
}
