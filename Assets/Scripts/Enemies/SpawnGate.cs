using System.Collections;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] GameObject robotPrefab;
    [SerializeField] float spawnTime = 5f;
    [SerializeField] Transform spawnPoint;
    PlayerHealth player;
    private void Awake()
    {
        player = FindFirstObjectByType<PlayerHealth>();
    }
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while(player)
        {
            Instantiate(robotPrefab,spawnPoint.position, transform.rotation);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
