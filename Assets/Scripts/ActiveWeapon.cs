using StarterAssets;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO startingWeaponSO;
    [SerializeField] TMP_Text ammoText;
    [SerializeField] GameObject zoomVignette;
    [SerializeField] CinemachineCamera playerFollowCamera;
    private Animator animator;

    WeaponSO currentWeaponSO;
    StarterAssetsInputs starterAssetsInputs;
    FirstPersonController firstPersonController;
    Weapons currentWeapon;

    float defualtFOV;
    float defualtRotationSpeed;

    const string GUN_KICKBACK = "GunKickback";

    float timeSinceLastFire = 0f;
    int currentAmmo;

    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        firstPersonController = GetComponentInParent<FirstPersonController>();
        animator = GetComponent<Animator>();
        defualtFOV = playerFollowCamera.Lens.FieldOfView;
        defualtRotationSpeed = firstPersonController.RotationSpeed;
    }
    private void Start()
    {
        SwitchWeapon(startingWeaponSO);
    }

    private void Update()
    {
        timeSinceLastFire += Time.deltaTime;
        HandleShooting();
        HandleZoom();
    }

    public void AdjustAmmo(int amount)
    {
        currentAmmo += amount;
        if (currentAmmo > currentWeaponSO.MagazineSize)
        {
            currentAmmo = currentWeaponSO.MagazineSize;
        }

        ammoText.text = currentAmmo.ToString();
    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        if (currentWeapon)
        {
            Destroy(currentWeapon.gameObject);

        }
        Weapons newWeapon = Instantiate(weaponSO.WeaponPrefab, transform).GetComponent<Weapons>();
        currentWeapon = newWeapon;
        this.currentWeaponSO = weaponSO;
        AdjustAmmo(currentWeaponSO.MagazineSize);
    }

    private void HandleShooting()
    {
        if (!starterAssetsInputs.shoot) return;

        if (timeSinceLastFire >= currentWeaponSO.FireRate && currentAmmo > 0)
        {
            currentWeapon.Shoot(currentWeaponSO);
            animator.Play(GUN_KICKBACK, 0, 0f);
            AdjustAmmo(-1);
            timeSinceLastFire = 0; ;
        }

        if (!currentWeaponSO.IsAutomatic)
        {
            starterAssetsInputs.ShootInput(false);
        }
    }

    private void HandleZoom()
    {
        if (!currentWeaponSO.CanZoom) return;

        if (starterAssetsInputs.zoom)
        {
            playerFollowCamera.Lens.FieldOfView = currentWeaponSO.ZoomAmount;
            zoomVignette.SetActive(true);
            firstPersonController.ChangeRotationSpeed(currentWeaponSO.RotationSpeed);
        }
        else
        {
            playerFollowCamera.Lens.FieldOfView = defualtFOV;
            zoomVignette.SetActive(false);
            firstPersonController.ChangeRotationSpeed(defualtRotationSpeed);
        }
    }
}
