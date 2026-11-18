using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]int startingHealth = 3;
    [SerializeField] GameObject robotExplosionPrefab;
    int currentHealth;
    private void Awake()
    {
        currentHealth = startingHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(robotExplosionPrefab, transform.position, Quaternion.identity);
        }
    }
}
