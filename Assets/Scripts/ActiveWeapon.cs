using StarterAssets;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    private Animator animator;

    StarterAssetsInputs starterAssetsInputs;
    Weapons currentWeapon;

    const string GUN_KICKBACK = "GunKickback";

    float timeSinceLastFire = 0f;

    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        currentWeapon = GetComponentInChildren<Weapons>();
    }

    private void Update()
    {
        timeSinceLastFire += Time.deltaTime;
        HandleShooting();
    }

    private void HandleShooting()
    {
        if (!starterAssetsInputs.shoot) return;

        if(timeSinceLastFire >= weaponSO.FireRate)
        {
            currentWeapon.Shoot(weaponSO);
            animator.Play(GUN_KICKBACK, 0, 0f);
        }
        starterAssetsInputs.ShootInput(false);
    }
}
