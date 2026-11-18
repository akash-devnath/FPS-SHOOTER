using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] LayerMask interactLayer;

    public void Shoot(WeaponSO weaponSO)
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, weaponSO.FireRange, interactLayer, QueryTriggerInteraction.Ignore))
        {
            Instantiate(weaponSO.HitVFXPrefab, hit.point, Quaternion.identity);
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(weaponSO.Damage);
        }
    }
}
