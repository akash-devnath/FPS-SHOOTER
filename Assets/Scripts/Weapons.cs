using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] private ParticleSystem muzzleFlash;

    public void Shoot(WeaponSO weaponSO)
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, weaponSO.FireRange))
        {
            Instantiate(weaponSO.HitVFXPrefab, hit.point, Quaternion.identity);
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(weaponSO.Damage);
        }
    }
}
