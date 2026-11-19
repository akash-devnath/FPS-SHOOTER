using UnityEngine;

public class EnemyGate : MonoBehaviour
{
    [SerializeField] int startingHealth = 10;
    [SerializeField] GameObject robotExplosionPrefab;
    int currentHealth;
    GameManager gameManager;

    private void Awake()
    {
        currentHealth = startingHealth;
    }
    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        gameManager.AdjustEnemyGate(1);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0 )
        {
            SelfDestruct();
            gameManager.AdjustEnemyGate(-1);
        }
    }

    public void SelfDestruct()
    {
        Instantiate(robotExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
