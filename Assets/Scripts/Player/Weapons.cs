using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] LayerMask interactLayer;

    public void Shoot(WeaponSO weaponSO)
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, weaponSO.FireRange, interactLayer, QueryTriggerInteraction.Collide))
        {
            Instantiate(weaponSO.HitVFXPrefab, hit.point, Quaternion.identity);
            EnemyHealth enemyHealth = hit.collider.GetComponentInParent<EnemyHealth>();
            EnemyGate enemyGate = hit.collider.GetComponentInParent<EnemyGate>();
            enemyHealth?.TakeDamage(weaponSO.Damage);
            enemyGate?.TakeDamage(weaponSO.Damage);
        }
    }
}
