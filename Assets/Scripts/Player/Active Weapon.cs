using StarterAssets;
using System.Collections;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    float cooldownTime = 0f;
    const string SHOOT_ANIMATION = "Shooting";
    float defaultFOV;
    float defaultRotationSpeed;
    int currentAmmo;

    StarterAssetsInputs starterAssetsInputs;
    Animator animator;
    Weapon currentWeapon;
    FirstPersonController firstPersonController;

    // CurrentWeaponSO is working as intended basically converting our staring weapon as well as pickupweapon to current weapon
    WeaponSO currentWeaponSO;
    
    [SerializeField] GameObject zoomVignette;
    [SerializeField] CinemachineCamera cam;
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] Camera weaponCamera; // Weapon Camera zoom setting

    // Using startingWeaponSO to manually set the weapon instead of switching it with prefabs
    [SerializeField] WeaponSO startingWeaponSO;


    void Awake()
    {
        firstPersonController = GetComponentInParent<FirstPersonController>();
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponentInParent<Animator>();
        currentWeapon = GetComponentInChildren<Weapon>();
        defaultFOV = cam.Lens.FieldOfView;
        defaultRotationSpeed = firstPersonController.RotationSpeed;
    }

    void Start()
    {
        SwitchWeapon(startingWeaponSO);
        updateAmmoDisplay(currentWeaponSO.MagzineSize);
    }

    void Update()
    {
        handleShooting();
        handleZoom();
    }

    void handleShooting()
    {
        cooldownTime += Time.deltaTime;
        if (!starterAssetsInputs.shoot == true) return;

        if (cooldownTime >= currentWeaponSO.FireRate && currentAmmo > 0) 
        {
            currentWeapon.Shoot(currentWeaponSO);
            animator.Play(SHOOT_ANIMATION, 0, 0f);
            cooldownTime = 0f;
            updateAmmoDisplay(-1);
        }
        if (!currentWeaponSO.isAutomatic)
        {
            starterAssetsInputs.ShootInput(false);
        }
    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        if (currentWeapon)
        {
            Destroy(currentWeapon.gameObject);
        }
        Weapon newWeapon = Instantiate(weaponSO.prefabs, transform).GetComponentInChildren<Weapon>(); //.GetComponentInChildren<Weapon>() is converting the gameObject to Weapon object same as int to float
        currentWeapon = newWeapon;
        this.currentWeaponSO = weaponSO;
        updateAmmoDisplay(currentWeaponSO.MagzineSize);
    }

    void handleZoom()
    {
        if (!currentWeaponSO.canZoom) return;

        if (starterAssetsInputs.zoom)
        {
            cam.Lens.FieldOfView = currentWeaponSO.ZoomAmount;
            weaponCamera.fieldOfView = currentWeaponSO.ZoomAmount;
            zoomVignette.SetActive(true);
            firstPersonController.ChangeRotationSpeed(currentWeaponSO.RotationSpeed);
        }
        else
        {
            cam.Lens.FieldOfView = defaultFOV;
            weaponCamera.fieldOfView = defaultFOV;
            zoomVignette.SetActive(false);
            firstPersonController.ChangeRotationSpeed(defaultRotationSpeed);
        }
    }

    // To handle our ammo amount
    public void updateAmmoDisplay(int amount)
    {
        currentAmmo += amount;
        if (currentAmmo > currentWeaponSO.MagzineSize)
        {
            currentAmmo = currentWeaponSO.MagzineSize;
        }
        ammoText.text = currentAmmo.ToString("D2");
    }
}
