using System.Collections;
using UnityEngine;

public class GunEnemy : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform gunHead;
    [SerializeField] Transform playerTargetPoint;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float fireRate = 2f;
    [SerializeField] int damage = 2;

    PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(SpawnRoutine());
    }

    private void Update()
    {
        gunHead.transform.LookAt(playerTargetPoint);
    }

    IEnumerator SpawnRoutine()
    {
        while(playerHealth)
        {
            yield return new WaitForSeconds(fireRate);
            Projectile newProject = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity).GetComponent<Projectile>();
            newProject.transform.LookAt(playerTargetPoint);
            newProject.Init(damage);

        }
    }
}
