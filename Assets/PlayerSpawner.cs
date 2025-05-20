using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;

    private GameObject player;

    public void Spawn()
    {
        FindPlayer();
        MoveToSpawnPoint();
    }

    private void FindPlayer()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void MoveToSpawnPoint()
    {
        if (player != null)
            player.transform.position = spawnPoint.position;
    }
}
