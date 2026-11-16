using StarterAssets;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject hitVFXPrefab;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private float maxRange = 100f;
    [SerializeField] private int damageAmount = 1;

    StarterAssetsInputs starterAssetsInputs;

    const string GUN_KICKBACK = "GunKickback";

    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    private void Update()
    {
        bool flowControl = HandleShooting();
        if (!flowControl)
        {
            return;
        }

    }

    private bool HandleShooting()
    {
        if (!starterAssetsInputs.shoot) return false;
        muzzleFlash.Play();
        starterAssetsInputs.ShootInput(false);
        animator.Play(GUN_KICKBACK,0,0f);
        
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxRange))
        {
            Instantiate(hitVFXPrefab, hit.point, Quaternion.identity);
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(damageAmount);
        }
        return true;
    }
}
