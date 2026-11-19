using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float radius = 1f;
    [SerializeField] int damage = 2;

    void Start()
    {
        Explode();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void Explode()
    {
        Collider[] hitCollider = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider collider in hitCollider)
        {
            PlayerHealth playerHealth = collider.GetComponent<PlayerHealth>();

            if(!playerHealth) continue;

            playerHealth.TakeDamage(damage);

            break;
        }

    }

}
