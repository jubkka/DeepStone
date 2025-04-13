using UnityEngine;

public class BordersGizmo : MonoBehaviour
{
    private LevelGeneration levelGeneration;

    private Vector3 bottomLeft;
    private Vector3 bottomRight;
    
    private Vector3 topLeft;
    private Vector3 topRight;

    private void Init()
    {
        levelGeneration = GetComponentInParent<LevelGeneration>();
        
        bottomLeft = Vector3.zero;
        bottomRight = new Vector3(levelGeneration.levelSize, 0f, 0f);
        topLeft = new Vector3(0f, 0f, levelGeneration.levelSize);
        topRight = new Vector3(levelGeneration.levelSize, 0f, levelGeneration.levelSize);
    }

    public void OnDrawGizmos()
    {
        DrawPerimeter();
    }

    private void DrawPerimeter()
    {
        Init();
        
        Gizmos.color = Color.blue;
        
        Gizmos.DrawLine(bottomLeft, bottomRight);
        Gizmos.DrawLine(bottomRight, topRight);
        Gizmos.DrawLine(topRight, topLeft); 
        Gizmos.DrawLine(topLeft, bottomLeft);
    }
}