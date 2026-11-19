using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] GameObject hitVFXPrefab;

    Rigidbody rb;
    private int damage;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.linearVelocity = transform.forward * speed;
    }

    public void Init(int damage)
    {
        this.damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        playerHealth?.TakeDamage(damage);
        Instantiate(hitVFXPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
